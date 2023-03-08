using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerItem : Item
{
    public ContainerItem(ItemSO itemScriptableObject) : base(itemScriptableObject)
    {
    }

    public void Open()
    {
        Debug.Log("Container opened!");
    }

    public override ContextMenuManager.ContextMenuItem[] GetActions()
    {
        List<ContextMenuManager.ContextMenuItem> menuItems = new List<ContextMenuManager.ContextMenuItem>();
        
        menuItems.Add(new ContextMenuManager.ContextMenuItem 
        { 
            Label = "Open", 
            OnClickHandler = () => Open()
        });

        menuItems.Add(new ContextMenuManager.ContextMenuItem 
        { 
            Label = "Cancel", 
            OnClickHandler = () => {}
        });

        return menuItems.ToArray();
    }
}
