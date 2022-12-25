using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractArea : MonoBehaviour
{
    public delegate void OnClickDelegate();
    public event OnClickDelegate OnClick;
    public delegate void OnDragDelegate();
    public event OnDragDelegate OnDrag;

    void OnMouseDown()
    {
        OnClick?.Invoke();
    }

    //called every frame while holding down mouse
    void OnMouseDrag()
    {
        OnDrag?.Invoke();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
    }
}
