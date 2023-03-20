using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpuItem : ComponentItem
{
    public ulong MegaHashesPerSecond { get { return ((GpuItemSO)itemScriptableObject).megaHashesPerSecond; } }
    public GpuItem(ItemSO itemScriptableObject) : base(itemScriptableObject)
    {
    }
}
