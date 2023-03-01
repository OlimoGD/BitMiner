using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryUI : MonoBehaviour
{
    [SerializeField]
    private Inventory playerInventory;
    [SerializeField]
    private Sprite blockedSlotSprite;
    [SerializeField]
    private ItemSlotUI[] itemSlots;

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
        itemSlots[index].Item = newItem;
    }

    private void SetBlockedInventorySlotSprites()
    {
        for (int i = playerInventory.Size; i < playerInventory.MaxSize; i++)
        {
            itemSlots[i].SetSprite(blockedSlotSprite);
        }
    }
}
