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
        StartCoroutine(DeliverItemPeriodically());
    }

    private IEnumerator DeliverItemPeriodically()
    {
        while(true)
        {
            yield return new WaitForSeconds(deliveryFrequencyInSeconds);
            playerInventory.Push(new Item(itemToDeliver));
        }
    }
}
