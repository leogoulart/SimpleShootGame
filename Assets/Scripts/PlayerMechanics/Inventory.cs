using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private List<ItemBaseSO> items = new List<ItemBaseSO>();

    public void CollectItem(CollectableItem obj)
    {
        var newItem = obj.itemRef;

        if (items.FindAll(i => i.GetType() == newItem.GetType()).Count < newItem.maxStackItemQuant)
        {
            items.Add(newItem);
            Destroy(obj.gameObject);
        }
        else
            Debug.Log($"Nao pode carregar mais {newItem.name}");
    } 
}
