using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Draggable : MonoBehaviour
{
    [SerializeField]
    private InteractArea interactArea;
    private Rigidbody2D rigidb;
    private Vector3 mouseOffset;

    private void Reset()
    {
        rigidb = GetComponent<Rigidbody2D>();
        rigidb.bodyType = RigidbodyType2D.Dynamic;
        rigidb.mass = 0.0001f;
        rigidb.angularDrag = 0f;
        rigidb.drag = 0f;
        rigidb.gravityScale = 0f;
        rigidb.freezeRotation = true;
        rigidb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    private void OnEnable()
    {
        interactArea.OnClick += OnClick;
        interactArea.OnDrag += OnDrag;
    }

    private void OnDisable()
    {
        interactArea.OnClick -= OnClick;
        interactArea.OnDrag -= OnDrag;
    }

    private void OnClick()
    {
        mouseOffset = gameObject.transform.position - MouseWorldPos();
    }

    private void OnDrag()
    {
        Vector3 newPos = MouseWorldPos() + mouseOffset;
        GetComponent<Rigidbody2D>().MovePosition(newPos);
    }

    private Vector3 MouseWorldPos()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
