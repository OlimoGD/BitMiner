using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContainerItem : Item
{
    private GpuBoxSpawner gpuBoxSpawner;

    public ContainerItem(ItemSO itemScriptableObject) : base(itemScriptableObject)
    {
        gpuBoxSpawner = GameObject.FindWithTag("GpuBoxSpawner").GetComponent<GpuBoxSpawner>();
    }

    public GameObject GpuBoxToSpawnPrefab
    {
        get 
        {
            return ((ContainerItemSO)this.itemScriptableObject).gpuBoxToSpawnPrefab;
        }
    }

    public void Open()
    {
        bool success = gpuBoxSpawner.SpawnGpuBox(this);
        if(success)
        {
            Inventory.Delete(this);
        }
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
