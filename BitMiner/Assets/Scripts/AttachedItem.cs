using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachedItem : MonoBehaviour
{
    [SerializeField]
    private ItemSO item;
    private Item i;
    public Item Item { get{ return i; } }
    
    private void Start()
    {
        i = item.ToItem();
    }
}
