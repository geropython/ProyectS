using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Scriptables/Item/Consumable", order = 0)]
public class ItemConsumable : ItemSO
{
    private void OnEnable()
    {
        itemCategories = ItemCategories.Consumable;
    }
}