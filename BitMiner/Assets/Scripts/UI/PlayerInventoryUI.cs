using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;
    [SerializeField]
    private GameObject slotsContainerGO;
    [SerializeField]
    private Sprite blockedSlotSprite;

    private void Start()
    {
        SetBlockedInventorySlotSprites();
    }

    private void OnEnable()
    {
        playerInventory.OnItemSlotChanged += OnItemSlotChanged;
    }

    private void OnDisable()
    {
        playerInventory.OnItemSlotChanged -= OnItemSlotChanged;
    }

    private void OnItemSlotChanged(int index, Item newItem)
    {
        GameObject ItemSlotsUIGO = slotsContainerGO.transform.Find($"ItemSlot{index}").gameObject;
        GameObject ItemUIGO = ItemSlotsUIGO.transform.Find($"Item{index}").gameObject;
        Image itemImage = ItemUIGO.GetComponent<Image>();
        if(newItem == null)
        {
            itemImage.enabled = false;
            itemImage.sprite = null;
        }
        else
        {
            itemImage.sprite = newItem.Sprite;
            itemImage.enabled = true;
        }
    }

    private void SetBlockedInventorySlotSprites()
    {
        for (int i = playerInventory.Size; i < playerInventory.MaxSize; i++)
        {
            GameObject ItemSlotsUIGO = slotsContainerGO.transform.Find($"ItemSlot{i}").gameObject;
            GameObject ItemUIGO = ItemSlotsUIGO.transform.Find($"Item{i}").gameObject;
            Image itemImage = ItemUIGO.GetComponent<Image>();
            itemImage.sprite = blockedSlotSprite;
            itemImage.enabled = true;
        }
    }
}
