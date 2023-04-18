using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    private Dictionary<int, int> _playerInventory = new();

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

    public int CheckItem(int id)
    {
        var value = 0;
        _playerInventory.TryGetValue(id, out value);
        Debug.LogWarning($"Amount:{value}");
        return value;
    }
}