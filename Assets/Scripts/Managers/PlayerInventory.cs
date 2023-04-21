using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<int, int> _playerInventory = new();
    public Dictionary<int, int> PlayerInventoryDic => _playerInventory;

    private Dictionary<ItemSO, int> _playerInventorySO = new();
    public Dictionary<ItemSO, int> PlayerInventoryDicSO => _playerInventorySO;

    // Agrega cantidad especifica a un item en el inventario
    public void AddItem(int id, int addQuantity)
    {
        if (_playerInventory.TryGetValue(id, out var oldQuantity))
        {
            _playerInventory[id] = oldQuantity + addQuantity;
        }
        else
        {
            _playerInventory.Add(id, addQuantity);
        }
    }

    // Saca cantidad especifica de un item del inventario
    public void RemoveItem(int id, int removeQuantity)
    {
        if (!_playerInventory.TryGetValue(id, out var oldQuantity)) return;
        if (oldQuantity <= removeQuantity)
        {
            _playerInventory[id] = 0;
        }
        else
        {
            _playerInventory[id] = oldQuantity - removeQuantity;
        }
    }

    // Pide un item y devuelve la cantidad que hay en inventario (para ui)
    public int CheckItem(int id)
    {
        var value = 0;
        _playerInventory.TryGetValue(id, out value);
        return value;
    }

    // Confirma que hay cierta cantidad de item en el inventario (para craft)
    public bool CheckItem(int id, int quantity)
    {
        var value = 0;
        _playerInventory.TryGetValue(id, out value);
        return value >= quantity;
    }

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

    public int CheckItemSO(ItemSO item)
    {
        var value = 0;
        _playerInventorySO.TryGetValue(item, out value);
        return value;
    }

    public bool CheckItemSO(ItemSO item, int quantity)
    {
        var value = 0;
        _playerInventorySO.TryGetValue(item, out value);
        return value >= quantity;
    }
}