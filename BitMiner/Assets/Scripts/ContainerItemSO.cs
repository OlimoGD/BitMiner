using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/ContainerItem")]
public class ContainerItemSO : ItemSO
{
    public GameObject gpuBoxToSpawnPrefab;

    public override Item ToItem()
    {
        return new ContainerItem(this);
    }
}
