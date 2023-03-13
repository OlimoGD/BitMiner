using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MiningRig : MonoBehaviour
{
    public delegate void GpuAddedDelegate(GpuItem gpuItem);
    public event GpuAddedDelegate OnGpuAdded;

    private List<GpuItem> gpus = new List<GpuItem>();
    public List<GpuItem> Gpus { get { return gpus.ToList(); } }

    public void AddComponent(ComponentItem component)
    {
        if(component is GpuItem)
        {
            gpus.Add((GpuItem)component);
            OnGpuAdded?.Invoke((GpuItem)component);
        }
    }
}
