using System;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    [SerializeField] private Pickup pickupPrefab;

    private Dictionary<ItemSO, int> _playerInventorySO;
    public Dictionary<ItemSO, int> PlayerInventoryDicSO => _playerInventorySO;

    private void Awake()
    {
        _playerInventorySO = new();
    }

    // Agrega el item al inventario, si ya estaba le suma la cantidad extra, sino crea una nueva entrada y le asigna ese valor
    public void AddItemSO(ItemSO item, int addQuantity)
    {
        if (_playerInventorySO.TryGetValue(item, out var oldQuantity))
        {
            _playerInventorySO[item] = oldQuantity + addQuantity;
        }
        else
        {
            _playerInventorySO.Add(item, addQuantity);
        }
    }

    // Lo mismo que agregar pero al reves
    public void RemoveItemSO(ItemSO item, int removeQuantity)
    {
        if (!_playerInventorySO.TryGetValue(item, out var oldQuantity)) return;
        if (oldQuantity <= removeQuantity)
        {
            _playerInventorySO[item] = 0;
        }
        else
        {
            _playerInventorySO[item] = oldQuantity - removeQuantity;
        }
    }

    // Devuelve la cantidad que hay del item pedido
    public int CheckItemSO(ItemSO item)
    {
        _playerInventorySO.TryGetValue(item, out var itemQuantity);
        return itemQuantity;
    }

    // Comprueba si el item pedido tiene la cantidad adecuada
    public bool CheckItemSO(ItemSO item, int requiredQuantity)
    {
        _playerInventorySO.TryGetValue(item, out var itemQuantity);
        return itemQuantity >= requiredQuantity;
    }

    public void DropItemSO()
    {
        
    }
}