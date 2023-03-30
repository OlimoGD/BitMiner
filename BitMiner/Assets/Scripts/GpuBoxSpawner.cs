using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GpuBoxSpawner : MonoBehaviour
{
    public delegate void OnGpuSpawnedDelegate(GPU gpu);
    public event OnGpuSpawnedDelegate OnGpuSpawned;

    [SerializeField]
    private CameraUtils cameraUtils;
    [SerializeField]
    private AudioManager audioManager;
    [SerializeField]
    private AudioClip boxSpawnSound;

    private GameObject spawnedGpuBox;

    public bool SpawnGpuBox(ContainerItem gpuBoxItem)
    {
        //can only have one box active
        if(spawnedGpuBox != null) return false;
        spawnedGpuBox = Instantiate(gpuBoxItem.GpuBoxToSpawnPrefab, Vector3.zero, Quaternion.identity, null);
        GPUBox gpuBox = spawnedGpuBox.GetComponentInChildren<GPUBox>();
        gpuBox.audioManager = audioManager;
        GPU gpu = spawnedGpuBox.GetComponentInChildren<GPU>();
        gpu.cameraUtils = cameraUtils;
        gpu.audioManager = audioManager;

        audioManager.Play(boxSpawnSound, 1f);

        OnGpuSpawned?.Invoke(gpu);
        return true;
    }
}
