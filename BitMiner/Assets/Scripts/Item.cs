using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    private ItemSO itemScriptableObject;

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

    public Item(ItemSO itemScriptableObject)
    {
        this.itemScriptableObject = itemScriptableObject;
    }
}
