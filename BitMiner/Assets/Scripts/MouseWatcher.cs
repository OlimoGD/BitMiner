using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class MouseWatcher : MonoBehaviour
{
    public delegate void OnMouseIsOverDelegate(List<GameObject> gameObjects);
    public event OnMouseIsOverDelegate OnMouseIsOver;

    private void Update()
    {
        CheckIfMouseIsOverSomething();
    }

    private void CheckIfMouseIsOverSomething()
    {
        List<GameObject> hitGameObjects = new List<GameObject>();
        //hits are ordered by Z, hits[0] is the object with the lowest Z value;
        //Physics2D raycast will hit all objects with all kinds of Z values, it only cares about X and Y;
        RaycastHit2D[] hits = Physics2D.RaycastAll(
            MouseWorldPos(), -Vector2.up, 0.001f, LayerMask.GetMask("Mouse"));
        for (int i = 0; i < hits.Length; i++)
        {
            GameObject go = hits[i].transform.gameObject;
            if(go != null) hitGameObjects.Add(go);
        }

        OnMouseIsOver?.Invoke(hitGameObjects);
    }

    private Vector2 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
