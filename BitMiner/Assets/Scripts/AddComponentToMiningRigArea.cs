using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
//If you drag and drop a component item into the area it will add it to the mining rig
public class AddComponentToMiningRigArea : MonoBehaviour
{
    [SerializeField]
    private MiningRig miningRig;
    private ComponentItem itemInArea;
    private GameObject itemInAreaGameObject;

    private void Update()
    {
        if(Input.GetMouseButtonUp(0) && itemInArea != null)
        {
            miningRig.AddComponent(itemInArea);
            Destroy(itemInAreaGameObject);
            itemInArea = null;
            itemInAreaGameObject = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        AttachedItem attachedItem = other.attachedRigidbody.GetComponent<AttachedItem>();
        if(attachedItem == null) return;

        if(attachedItem.Item is ComponentItem)
        {
            itemInArea = (ComponentItem)attachedItem.Item;
            itemInAreaGameObject = attachedItem.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        AttachedItem attachedItem = other.attachedRigidbody.GetComponent<AttachedItem>();
        if(attachedItem == null) return;


        if(itemInArea == attachedItem.Item)
        {
            itemInArea = null;
            itemInAreaGameObject = null;
        }
    }
}
