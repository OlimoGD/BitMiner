using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class MiningRigGpusUI : MonoBehaviour
{
    [SerializeField]
    private MiningRig miningRig;
    [SerializeField]
    private GpuItemSO bolt510;
    
    [SerializeField]
    private TextMeshProUGUI bolt510CounterText;
    [SerializeField]
    private TextMeshProUGUI hashRateText;
    [SerializeField]
    private TextMeshProUGUI earningsText;

    private ulong totalHashRateInMegaHashesPerSecond;

    private void OnEnable()
    {
        UpdateDataOnUI();
        miningRig.OnGpuAdded += OnGpuAdded;
    }

    private void OnDisable()
    {
        miningRig.OnGpuAdded -= OnGpuAdded;
    }

    private void OnGpuAdded(GpuItem gpuItem)
    {
        UpdateDataOnUI();
    }

    private void UpdateDataOnUI()
    {
        UpdateGpuCounts();
        CalculateAndUpdateHashRate();
        CalculateEarnings();
    }

    private void UpdateGpuCounts()
    {
        int numberOfBolt510 = 0;
        foreach (GpuItem item in miningRig.Gpus)
        {
            if(item.Is(bolt510))
                numberOfBolt510++;
        }
        
        bolt510CounterText.text = numberOfBolt510.ToString();
    }

    private void CalculateAndUpdateHashRate()
    {
        ulong totalHashRate = 0;
        foreach (var item in miningRig.Gpus)
        {
            totalHashRate += item.MegaHashesPerSecond;
        }
        totalHashRateInMegaHashesPerSecond = totalHashRate;

        hashRateText.text = $"Hash rate: {totalHashRate} MH/s";
    }

    private void CalculateEarnings()
    {
        var coinsPerSecond = totalHashRateInMegaHashesPerSecond / (float)miningRig.CoinComputeCostInMegaHashes;
        earningsText.text = $"Earnings: {coinsPerSecond} bit/s";
    }
}
