using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ComponentItem")]
public class ComponentItemSO : ItemSO
{
    public override Item ToItem()
    {
        return new ComponentItem(this);
    }
}
