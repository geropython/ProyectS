using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerModel>())
        {
            foreach (var KvP in GameManager.Instance.PlayerInventory.PlayerInventoryDic)
            {
                Debug.LogWarning($"Item id:{KvP.Key}/Item amount:{KvP.Value}");
            }
        }
    }
}