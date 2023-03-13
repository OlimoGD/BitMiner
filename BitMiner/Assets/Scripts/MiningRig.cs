using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningRig : MonoBehaviour
{
    private List<GpuItem> gpus = new List<GpuItem>();

    public void AddComponent(ComponentItem component)
    {
        if(component is GpuItem)
        {
            gpus.Add((GpuItem)component);
        }
    }
}
