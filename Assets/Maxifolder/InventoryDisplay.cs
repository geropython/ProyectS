using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private string _inventoryDisplayText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerModel>())
        {
            foreach (var KvP in GameManager.Instance.PlayerInventory.PlayerInventoryDic)
            {
                Debug.LogWarning($"Item id:{KvP.Key}/Item amount:{KvP.Value}");
            }

            foreach (var KvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
            {
                _inventoryDisplayText += $"{KvP.Key.Identifier} x{KvP.Value} \n";
            }

            var text = string.Concat("Inventory \n ----- \n", _inventoryDisplayText);
            Debug.LogWarning(text);
        }
    }
}