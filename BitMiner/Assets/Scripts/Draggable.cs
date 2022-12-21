using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    [SerializeField]
    private HitBox hitBox;
    private Vector3 mouseOffset;

    private void OnEnable()
    {
        hitBox.OnClick += OnClick;
        hitBox.OnDrag += OnDrag;
    }

    private void OnDisable()
    {
        hitBox.OnClick -= OnClick;
        hitBox.OnDrag -= OnDrag;
    }

    private void OnClick()
    {
        mouseOffset = gameObject.transform.position - MouseWorldPos();
    }

    private void OnDrag()
    {
        gameObject.transform.position = MouseWorldPos() + mouseOffset;
    }

    private Vector3 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
