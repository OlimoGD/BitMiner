using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;

public class MouseWatcher : MonoBehaviour
{
    public delegate void OnMouseIsOverDelegate(List<GameObject> gameObjects);
    public event OnMouseIsOverDelegate OnMouseIsOver;

    private List<MouseArea> areasMouseWasOverPreviously = new List<MouseArea>();
    private List<MouseArea> areasMouseIsOver = new List<MouseArea>();
    private List<MouseArea> areasMouseEntered = new List<MouseArea>();
    private List<MouseArea> areasMouseExited = new List<MouseArea>();

    private List<MouseArea> areasPrimaryMouseButtonIsHeldDown = new List<MouseArea>();
    private List<MouseArea> areasSecondaryMouseButtonIsHeldDown = new List<MouseArea>();

    private void Update()
    {
        areasMouseWasOverPreviously = new List<MouseArea>(areasMouseIsOver);
        List<MouseArea> hitMouseAreas = CastRay();
        areasMouseIsOver = hitMouseAreas;
        areasMouseEntered = GetMouseEnters();
        areasMouseExited = GetMouseExits();

        CheckAndCallMouseHoverEvents();
        CheckAndCallMouseClickEvents(0, areasPrimaryMouseButtonIsHeldDown);
        CheckAndCallMouseClickEvents(1, areasSecondaryMouseButtonIsHeldDown);
    }

    private void CheckAndCallMouseHoverEvents()
    {
        for(int i = 0; i < areasMouseIsOver.Count; i++)
        {
            MouseArea ma = areasMouseIsOver[i];
            ma.MouseHover(i);
        }

        foreach (MouseArea ma in areasMouseEntered)
        {
            int i = areasMouseIsOver.FindIndex(item => item == ma);
            ma.MouseHoverEntered(i);
        }

        foreach (MouseArea ma in areasMouseExited)
        {
            ma.MouseHoverExited();
        }
    }

    private void CheckAndCallMouseClickEvents(int button, List<MouseArea> areasMouseButtonIsHeldDown)
    {
        for(int i = 0; i < areasMouseIsOver.Count; i++)
        {
            MouseArea ma = areasMouseIsOver[i];
            if(Input.GetMouseButtonDown(button))
            {
                areasMouseButtonIsHeldDown.Add(ma);
                ma.MouseButtonPressed(button, i);
            }
        }

        //for mouse holding and released it is not important whether
        //the cursor is over the mouse area (it is only important for the mouse press)
        List<MouseArea> areasToRemove = new List<MouseArea>();
        foreach (MouseArea ma in areasMouseButtonIsHeldDown)
        {
            if(Input.GetMouseButton(button))
            {
                ma.MouseButtonHolding(button);
            }
            else if(Input.GetMouseButtonUp(button))
            {
                areasToRemove.Add(ma);
                ma.MouseButtonReleased(button);
            }
        }
        foreach (MouseArea ma in areasToRemove)
        {
            areasMouseButtonIsHeldDown.Remove(ma);   
        }
    }

    private List<MouseArea> CastRay()
    {
        List<MouseArea> hitMouseAreas = new List<MouseArea>();
        //hits are ordered by Z, hits[0] is the object with the lowest Z value;
        //Physics2D raycast will hit all objects with all kinds of Z values, it only cares about X and Y;
        RaycastHit2D[] hits = Physics2D.RaycastAll(
            MouseWorldPos(), -Vector2.up, 0.001f, LayerMask.GetMask("Mouse"));
        for (int i = 0; i < hits.Length; i++)
        {
            MouseArea ma = hits[i].transform.gameObject.GetComponent<MouseArea>();
            if(ma != null) hitMouseAreas.Add(ma);
        }
        //sort the list so that the first element is the one with the highest Z value
        hitMouseAreas = hitMouseAreas.OrderByDescending(ma => ma.transform.position.z).ToList();
        return hitMouseAreas;
    }

    private Vector2 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private List<MouseArea> GetMouseEnters()
    {
        List<MouseArea> areasMouseEntered = new List<MouseArea>();
        foreach (MouseArea ma in areasMouseIsOver)
        {
            if(!areasMouseWasOverPreviously.Contains(ma))
            {
                areasMouseEntered.Add(ma);
            }
        }
        return areasMouseEntered;
    }

    private List<MouseArea> GetMouseExits()
    {
        List<MouseArea> areasMouseExited = new List<MouseArea>();
        foreach (MouseArea ma in areasMouseWasOverPreviously)
        {
            if(!areasMouseIsOver.Contains(ma))
            {
                areasMouseExited.Add(ma);
            }
        }
        return areasMouseExited;
    }
}
