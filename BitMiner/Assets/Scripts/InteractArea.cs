using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    public delegate void OnClickDelegate();
    public event OnClickDelegate OnClick;
    public delegate void OnReleaseDelegate();
    public event OnReleaseDelegate OnRelease;
    public delegate void OnDragDelegate();
    public event OnDragDelegate OnDrag;

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(MouseIsOverThisInteractArea())
            {
                OnClick?.Invoke();
            }
        }
        else if(Input.GetMouseButton(0))
        {
            if(MouseIsOverThisInteractArea())
            {
                OnDrag?.Invoke();
            }
        }
        else if(Input.GetMouseButtonUp(0))
        {
            if(MouseIsOverThisInteractArea())
            {
                OnRelease?.Invoke();
            }
        }
    }

    private bool MouseIsOverThisInteractArea()
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(MouseWorldPos(), -Vector2.up);
        for (int i = 0; i < hits.Length; i++)
        {
            if(hits[i].transform.gameObject.GetComponent<InteractArea>() == this)
            {
                return true;
            }
        }
        return false;
    }

    private Vector3 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
