using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/GpuItem")]
public class GpuItemSO : ComponentItemSO
{
    public ulong megaHashesPerSecond;
    public override Item ToItem()
    {
        return new GpuItem(this);
    }
}
