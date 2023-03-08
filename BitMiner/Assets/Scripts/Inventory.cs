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
    [SerializeField]
    private int maxSize = 18;
    public int MaxSize { get { return maxSize; } }
    

    private void Start()
    {
        if(initialSize > maxSize)
            initialSize = maxSize;
        itemSlots = new Item[initialSize];
    }

    public Item Get(int index)
    {
        return itemSlots[index];
    }

    public int Add(Item newItem)
    {
        //items can only be in 1 inventory at a time
        if(newItem.Inventory != null) return -1;
        int index = FirstFreeSlot();
        if(index == -1) return -1;

        itemSlots[index] = newItem;
        newItem.Inventory = this;
        OnItemSlotChanged?.Invoke(index, newItem);
        return index;
    }

    ///<summary>Deletes the item from the inventory.
    ///Returns -1 if deletion was unsuccessful.
    ///Otherwise returns the slot index where it was deleted from.</summary>
    public int Delete(Item item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if(itemSlots[i] == item)
            {
                itemSlots[i] = null;
                item.Inventory = null;
                OnItemSlotChanged?.Invoke(i, null);
                return i;
            }
        }

        return -1;
    }

    //TODO: setting item.inventory
    /*
    public void Resize(int size)
    {
        if(size > maxSize)
            size = maxSize;
        Item[] newItemSlots = new Item[Size];
        int howLong = Mathf.Min(itemSlots.Length, newItemSlots.Length);
        for (int i = 0; i < howLong; i++)
        {
            newItemSlots[i] = itemSlots[i];
        }
        itemSlots = newItemSlots;
    }*/

    public void Clear()
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i].Inventory = null;
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
