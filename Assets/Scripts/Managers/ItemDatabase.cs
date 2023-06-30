using System.Collections.Generic;
using UnityEngine;

public enum ItemCategories
{
    Equipment = 0,
    Consumable = 1,
    Material = 2,
    All = 3,
}

public class ItemDatabase : MonoBehaviour
{
    [SerializeField] private List<ItemSO> itemsSODatabase = new();

    public ItemSO GetItemSO(ItemSO itemSO)
    {
        return itemsSODatabase.Find(item => item == itemSO);
    }

    public ItemSO GetItemSO(string identifier)
    {
        return itemsSODatabase.Find(item => item.Identifier == identifier);
    }
}