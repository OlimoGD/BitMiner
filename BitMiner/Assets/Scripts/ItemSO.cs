using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public string description;
    public Sprite sprite;

    public virtual Item ToItem()
    {
        return new Item(this);
    }
}
