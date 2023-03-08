using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Linq;

public class ContextMenuManager : MonoBehaviour
{
    public class ContextMenuItem
    {
        public string Label { get; set; }
        public UnityAction OnClickHandler { get; set; }
    }

    [SerializeField]
    private float zIndex = 10;
    [SerializeField]
    private GameObject contextMenuPrefab;
    [SerializeField]
    private Canvas canvasToSpawnOn;

    private GameObject currentlyActiveContextMenu;

    public void SpawnContextMenu(ContextMenuItem[] items)
    {
        if(items == null)
            throw new System.ArgumentNullException("Context menu items are null!");
        if(currentlyActiveContextMenu != null)
            Destroy(currentlyActiveContextMenu);
        if(items.Length == 0) 
            return;

        DoSpawnContextMenu(items);
    }

    public void DestroyContextMenu()
    {
        Destroy(currentlyActiveContextMenu);
    }

    private void DoSpawnContextMenu(ContextMenuItem[] items)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = zIndex;
        GameObject contextMenuGo = Instantiate(contextMenuPrefab, 
            pos, Quaternion.identity, canvasToSpawnOn.transform);
        currentlyActiveContextMenu = contextMenuGo;
        ContextMenu contextMenu = contextMenuGo.GetComponent<ContextMenu>();
        string[] labels = items.Select(i => i.Label).ToArray();
        List<Button> buttons = contextMenu.CreateItems(labels);
        for(int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.AddListener(items[i].OnClickHandler);
            buttons[i].onClick.AddListener(OnContextMenuItemClicked);
        }
    }

    private void OnContextMenuItemClicked()
    {
        Destroy(currentlyActiveContextMenu);
    }
}
