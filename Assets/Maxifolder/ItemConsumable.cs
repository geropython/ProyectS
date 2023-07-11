using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Scriptables/Item/Consumable", order = 0)]
public class ItemConsumable : ItemSO
{
    // TODO:ConsumeActionScript

    // [SerializeField] private ConsumableAction _consumeAction;

    private void OnEnable()
    {
        itemCategories = ItemCategories.Consumable;
    }

    public void ConsumeItem()
    {
        // _consumeAction.Execute();
    }
}