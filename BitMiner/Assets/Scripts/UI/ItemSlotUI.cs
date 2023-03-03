using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlotUI : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;
    [SerializeField]
    private Image itemImage;
    [SerializeField]
    private ContextMenuManager contextMenuManager;

    private Item item;
    public Item Item
    {
        get { return item; }
        set { SetItem(value); }
    }

    [SerializeField]
    private MouseArea mouseArea;

    private void OnEnable()
    {
        mouseArea.OnMouseSecondaryButtonPressed += OnRightClick;
    }

    private void OnDisable()
    {
        mouseArea.OnMouseSecondaryButtonPressed -= OnRightClick;
    }

    public void SetSprite(Sprite sprite)
    {
        itemImage.sprite = sprite;
        itemImage.enabled = sprite != null;
    }

    private void OnRightClick(int zOrder)
    {
        if(zOrder != 0) return;
        if(item == null) return;
        contextMenuManager.SpawnContextMenu(new[]{
            new ContextMenuManager.ContextMenuItem { Label = "Open", OnClickHandler = OnOpenClicked },
            new ContextMenuManager.ContextMenuItem { Label = "Delete", OnClickHandler = OnDeleteClicked },
            new ContextMenuManager.ContextMenuItem { Label = "Cancel", OnClickHandler = OnCancelClicked }
        });
    }

    private void OnOpenClicked()
    {
        Debug.Log("Open");
    }

    private void OnDeleteClicked()
    {
        Debug.Log("Delete");
    }

    private void OnCancelClicked()
    {
        Debug.Log("Cancel");
    }

    private void SetItem(Item newItem)
    {
        item = newItem;

        if(newItem == null)
        {
            itemImage.enabled = false;
            itemImage.sprite = null;
        }
        else
        {
            itemImage.sprite = newItem.Sprite;
            itemImage.enabled = true;
        }
    }
}
