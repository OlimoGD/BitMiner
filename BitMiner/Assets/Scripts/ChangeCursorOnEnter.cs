using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

public class ChangeCursorOnEnter : MonoBehaviour
{
    [SerializeField]
    private Texture2D cursorTexture;
    [SerializeField]
    private MouseWatcher mouseWatcher;
    private bool mouseIsOverThisArea = false;

    private void OnEnable()
    {
        mouseWatcher.OnMouseIsOver += OnMouseIsOver;
    }

    private void OnDisable()
    {
        mouseWatcher.OnMouseIsOver -= OnMouseIsOver;
    }

    private void OnMouseIsOver(List<GameObject> gameObjects)
    {
        SetMouseIsOverThisArea(gameObjects.Contains(this.gameObject));
    }

    private void SetMouseIsOverThisArea(bool newValue)
    {
        bool prevValue = mouseIsOverThisArea;
        mouseIsOverThisArea = newValue;
        if(prevValue != newValue)
        {
            ChangeCursor();
        }
    }

    private void ChangeCursor()
    {
        if(mouseIsOverThisArea)
            Cursor.SetCursor(cursorTexture, Vector2.zero, CursorMode.Auto);
        else
            Cursor.SetCursor(PlayerSettings.defaultCursor, Vector2.zero, CursorMode.Auto);
    }
}
