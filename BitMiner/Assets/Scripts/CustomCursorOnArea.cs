using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CustomCursorOnArea : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;
    [SerializeField]
    private MouseArea mouseArea;

    private void OnEnable()
    {
        mouseArea.OnMouseHoverEntered += OnMouseHoverEntered;
        mouseArea.OnMouseHoverExited += OnMouseHoverExited;
    }

    private void OnDisable()
    {
        mouseArea.OnMouseHoverEntered -= OnMouseHoverEntered;
        mouseArea.OnMouseHoverExited -= OnMouseHoverExited;
    }

    private void OnMouseHoverEntered(int zOrder)
    {
        Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseHoverExited()
    {
        Cursor.SetCursor(PlayerSettings.defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
