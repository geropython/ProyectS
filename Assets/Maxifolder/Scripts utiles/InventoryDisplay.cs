using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private string _inventoryDisplayText;
    [SerializeField] private bool defaultInventory;
    [SerializeField] private bool materialInventory;
    [SerializeField] private bool consumableInventory;
    [SerializeField] private bool equipmentInventory;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (defaultInventory)
        {
            DefaultInventory(other);
        }

        if (materialInventory)
        {
            MaterialInventory(other);
        }

        if (consumableInventory)
        {
            ConsumableInventory(other);
        }

        if (equipmentInventory)
        {
            EquipmentInventory(other);
        }
    }

    private void DefaultInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void MaterialInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if (kvP.Key.ItemCategories == ItemCategories.Material)
            {
                _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
            }
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void ConsumableInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if (kvP.Key.ItemCategories == ItemCategories.Consumable)
            {
                _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
            }
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void EquipmentInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if (kvP.Key.ItemCategories == ItemCategories.Equipment)
            {
                _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
            }
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }
}