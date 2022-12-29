using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    public delegate void OnClickDelegate();
    public event OnClickDelegate OnClick;
    public delegate void OnReleaseDelegate();
    public event OnReleaseDelegate OnRelease;
    public delegate void OnDragDelegate();
    public event OnDragDelegate OnDrag;
    public delegate void OnAreaExitedDelegate(Collider2D colliderThatExited);
    public event OnAreaExitedDelegate OnAreaExited;

    [SerializeField]
    //If interact areas are overlapping only the top most will catch inputs.
    //An interact area with higher sort order is on top.
    private int sortOrder;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(MouseIsOverThisInteractAreaAndIsTopMost())
            {
                OnClick?.Invoke();
            }
        }
        else if(Input.GetMouseButton(0))
        {
            if(MouseIsOverThisInteractAreaAndIsTopMost())
            {
                OnDrag?.Invoke();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(MouseIsOverThisInteractAreaAndIsTopMost())
            {
                OnRelease?.Invoke();
            }
        }
    }

    private bool MouseIsOverThisInteractAreaAndIsTopMost()
    {
        List<InteractArea> hitInteractAreas = new List<InteractArea>();
        bool mouseIsOverThisInteractArea = false;
        int sortOrderOfThisInteractArea = 0;
        RaycastHit2D[] hits = Physics2D.RaycastAll(MouseWorldPos(), -Vector2.up);
        for (int i = 0; i < hits.Length; i++)
        {
            InteractArea ia = hits[i].transform.gameObject.GetComponent<InteractArea>();
            if(ia != null)
            {
                hitInteractAreas.Add(ia);
                if(ia == this)
                {
                    mouseIsOverThisInteractArea = true;
                    sortOrderOfThisInteractArea = this.sortOrder;
                }
            }
        }

        if(!mouseIsOverThisInteractArea)
            return false;
        
        int maxSortOrder = hitInteractAreas.Max(ia => ia.sortOrder);
        return sortOrderOfThisInteractArea == maxSortOrder;
    }

    private Vector3 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        OnAreaExited?.Invoke(other);
    }
}
