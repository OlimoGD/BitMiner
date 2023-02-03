using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public delegate void OnItemSlotChangedDelegate(int index, Item newItem);
    public event OnItemSlotChangedDelegate OnItemSlotChanged;

    [SerializeField]
    private int initialSize = 1;
    private Item[] itemSlots;
    public int Size { get { return itemSlots.Length; } }

    private void Start()
    {
        itemSlots = new Item[initialSize];
    }

    public void Set(int index, Item newItem)
    {
        itemSlots[index] = newItem;
        OnItemSlotChanged?.Invoke(index, newItem);
    }

    public Item Get(int index)
    {
        return itemSlots[index];
    }

    public bool Push(Item newItem)
    {
        int index = FirstFreeSlot();
        if(index == -1) return false;

        itemSlots[index] = newItem;
        OnItemSlotChanged?.Invoke(index, newItem);
        return true;
    }

    public void Resize(int size)
    {
        Item[] newItemSlots = new Item[Size];
        int howLong = Mathf.Min(itemSlots.Length, newItemSlots.Length);
        for (int i = 0; i < howLong; i++)
        {
            newItemSlots[i] = itemSlots[i];
        }
        itemSlots = newItemSlots;
    }

    public void Clear()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = null;
            OnItemSlotChanged?.Invoke(i, null);
        }
    }

    public int FirstFreeSlot()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i] == null)
                return i;
        }

        return -1;
    }
}
