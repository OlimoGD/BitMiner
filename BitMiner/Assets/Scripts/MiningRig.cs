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

    private const ulong howManyMegaHashPerCoin = 5000;
    private ulong megaHashesPerformed = 0;

    private void Start()
    {
        InvokeRepeating(nameof(Mine), 0f, 1f);
    }

    public void AddComponent(ComponentItem component)
    {
        if(component is GpuItem)
        {
            gpus.Add((GpuItem)component);
            OnGpuAdded?.Invoke((GpuItem)component);
        }
    }

    private void Mine()
    {
        foreach (GpuItem gpu in gpus)
        {
            megaHashesPerformed += gpu.MegaHashesPerSecond;
        }
        ulong coinsToAdd = ConvertPerformedMegaHashesToCoins();
        ScoreCounter.Instance.AddScore(coinsToAdd);
    }

    private ulong ConvertPerformedMegaHashesToCoins()
    {
        int x = Mathf.FloorToInt(megaHashesPerformed / howManyMegaHashPerCoin);
        ulong howManyToConvert = howManyMegaHashPerCoin * (ulong)x;
        megaHashesPerformed -= howManyToConvert;
        return howManyToConvert / howManyMegaHashPerCoin;
    }
}
