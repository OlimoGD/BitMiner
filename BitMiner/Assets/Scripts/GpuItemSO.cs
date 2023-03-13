using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GpuItem")]
public class GpuItemSO : ComponentItemSO
{
    public override Item ToItem()
    {
        return new GpuItem(this);
    }
}
