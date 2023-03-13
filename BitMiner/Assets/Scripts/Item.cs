using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    protected ItemSO itemScriptableObject;

    public string ItemName 
    {
        get { return itemScriptableObject.itemName; }
    }
    
    public string Description 
    {
        get { return itemScriptableObject.description; }
    }

    public Sprite Sprite 
    {
        get { return itemScriptableObject.sprite; }
    }

    public Inventory Inventory { get; set; }

    public Item(ItemSO itemScriptableObject)
    {
        this.itemScriptableObject = itemScriptableObject;
    }

    public virtual ContextMenuManager.ContextMenuItem[] GetActions()
    {
        List<ContextMenuManager.ContextMenuItem> menuItems = new List<ContextMenuManager.ContextMenuItem>();
        
        menuItems.Add(new ContextMenuManager.ContextMenuItem 
        { 
            Label = "Cancel", 
            OnClickHandler = () => {}
        });

        return menuItems.ToArray();
    }

    public bool Is(ItemSO itemSO)
    {
        if(itemSO == null) 
            return false;
        return  itemScriptableObject == itemSO;
    }
}
