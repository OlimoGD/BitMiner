using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MiningRigGpusUI : MonoBehaviour
{
    [SerializeField]
    private MiningRig miningRig;
    [SerializeField]
    private GpuItemSO bolt510;
    
    [SerializeField]
    private TextMeshProUGUI bolt510CounterText;

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
        int numberOfBolt510 = 0;
        foreach (GpuItem item in miningRig.Gpus)
        {
            if(item.Is(bolt510))
                numberOfBolt510++;
        }
        
        bolt510CounterText.text = numberOfBolt510.ToString();
    }
}
