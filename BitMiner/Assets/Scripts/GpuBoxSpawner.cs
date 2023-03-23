using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpuBoxSpawner : MonoBehaviour
{
    [SerializeField]
    private CameraUtils cameraUtils;
    [SerializeField]
    private AudioManager audioManager;

    private GameObject spawnedGpuBox;

    public bool SpawnGpuBox(ContainerItem gpuBoxItem)
    {
        //can only have one box active
        if(spawnedGpuBox != null) return false;
        spawnedGpuBox = Instantiate(gpuBoxItem.GpuBoxToSpawnPrefab, Vector3.zero, Quaternion.identity, null);
        GPU gpu = spawnedGpuBox.GetComponentInChildren<GPU>();
        gpu.cameraUtils = cameraUtils;
        gpu.audioManager = audioManager;
        return true;
    }
}
