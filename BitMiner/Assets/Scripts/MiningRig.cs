using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class MiningRig : MonoBehaviour
{
    public delegate void GpuAddedDelegate(GpuItem gpuItem);
    public event GpuAddedDelegate OnGpuAdded;

    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioClip gpuInsertSound;
    private List<GpuItem> gpus = new List<GpuItem>();
    public List<GpuItem> Gpus { get { return gpus.ToList(); } }

    [SerializeField]
    private ulong coinComputeCostInMegaHashes = 10000;
    public ulong CoinComputeCostInMegaHashes { get { return coinComputeCostInMegaHashes; } }

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
            audioManager.Play(gpuInsertSound, 0.6f, Random.Range(0.95f, 1.1f));
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
        int x = Mathf.FloorToInt(megaHashesPerformed / coinComputeCostInMegaHashes);
        ulong howManyToConvert = coinComputeCostInMegaHashes * (ulong)x;
        megaHashesPerformed -= howManyToConvert;
        return howManyToConvert / coinComputeCostInMegaHashes;
    }
}
