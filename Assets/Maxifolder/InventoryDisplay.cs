using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private string _inventoryDisplayText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }
}