using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField]
    private int deliveryFrequencyInSeconds = 20;
    [SerializeField]
    private ItemSO itemToDeliver;
    [SerializeField]
    private Inventory playerInventory;

    private void Start()
    {
        InvokeRepeating(nameof(DeliverItem), 2f, deliveryFrequencyInSeconds);
    }

    private void DeliverItem()
    {
        playerInventory.Add(new ContainerItem(itemToDeliver));
    }
}
