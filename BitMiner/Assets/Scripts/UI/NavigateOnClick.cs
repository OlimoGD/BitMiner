using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigateOnClick : MonoBehaviour
{
    [SerializeField]
    private MouseArea mouseArea;
    [SerializeField]
    private ViewNavigationManager.ViewName viewName;
    public ViewNavigationManager viewNavigationManager;

    private void OnEnable()
    {
        mouseArea.OnMousePrimaryButtonPressed += OnClick;
    }

    private void OnDisable()
    {
        mouseArea.OnMousePrimaryButtonPressed -= OnClick;
    }

    private void OnClick(int zOrder)
    {
        if(zOrder != 0) return;
        viewNavigationManager.NavigateTo(viewName);
    }
}
