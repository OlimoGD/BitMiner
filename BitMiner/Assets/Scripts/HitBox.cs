using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    public delegate void OnClickDelegate();
    public event OnClickDelegate OnClick;

    void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
