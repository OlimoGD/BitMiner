using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ViewNavigationManager : MonoBehaviour
{
    public enum ViewName
    {
        NONE = -1,
        MAIL_LIST = 0,
        MAIL_DETAILS = 1,
        STORAGE = 2,
        WALLET = 3,
        MINING_RIG = 4,
        MINING_RIG_GPUS = 5
    }

    [Serializable]
    private class Route
    {
        public ViewName viewName;
        public GameObject view;
    }

    [SerializeField]
    //the first view to be active
    private ViewName startingView;
    [SerializeField]
    private Route[] routes;
    private GameObject currentlyActiveView;

    private void Start()
    {
        ActivateStartingViewAndDisableOtherViews();
    }

    public void NavigateTo(ViewName viewName)
    {
        if(currentlyActiveView != null)
            currentlyActiveView.SetActive(false);
        GameObject view = FindView(viewName);
        if(view == null) return;
        view.SetActive(true);
        currentlyActiveView = view;
    }

    private void ActivateStartingViewAndDisableOtherViews()
    {
        for (int i = 0; i < routes.Length; i++)
        {
            if(routes[i].viewName != startingView)
            {
                routes[i].view.SetActive(false);
            }
            else
            {
                routes[i].view.SetActive(true);
                currentlyActiveView = routes[i].view;
            }
        }
    }

    private GameObject FindView(ViewName viewName)
    {
        for (int i = 0; i < routes.Length; i++)
        {
            if(routes[i].viewName == viewName)
                return routes[i].view;
        }
        return null;
    }
}
