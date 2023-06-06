using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    private string _inventoryDisplayText;
    [SerializeField] private bool defaultInventory;
    [SerializeField] private bool materialInventory;
    [SerializeField] private bool consumableInventory;
    [SerializeField] private bool equipmentInventory;

    [SerializeField] private GameObject popupMenu;
    [SerializeField] private Transform contentContainer;
    [SerializeField] private UI_ItemContainer itemPrefab;

    private List<UI_ItemContainer> _itemsGenerated = new List<UI_ItemContainer>();

    private void GenerateItem(ItemSO itemSo)
    {
        var go = Instantiate(itemPrefab, contentContainer, true);
        if (!_itemsGenerated.Contains(go))
        {
            _itemsGenerated.Add(go);
        }

        go.SetupButton(itemSo.Icon, itemSo.Identifier);

        //reset the item's scale -- this can get munged with UI prefabs
        go.transform.localScale = Vector2.one;
    }

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
        foreach (var item in _itemsGenerated)
        {
            Destroy(item.gameObject);
        }

        _itemsGenerated.Clear();
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
            GenerateItem(kvP.Key);
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void MaterialInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var item in _itemsGenerated)
        {
            Destroy(item.gameObject);
        }

        _itemsGenerated.Clear();
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if (kvP.Key.ItemCategories == ItemCategories.Material)
            {
                _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
                GenerateItem(kvP.Key);
            }
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void ConsumableInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var item in _itemsGenerated)
        {
            Destroy(item.gameObject);
        }

        _itemsGenerated.Clear();
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if (kvP.Key.ItemCategories == ItemCategories.Consumable)
            {
                _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
                GenerateItem(kvP.Key);
            }
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void EquipmentInventory(Collider2D other)
    {
        if (!other.GetComponent<PlayerModel>()) return;
        _inventoryDisplayText = "";
        foreach (var item in _itemsGenerated)
        {
            Destroy(item.gameObject);
        }

        _itemsGenerated.Clear();
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if (kvP.Key.ItemCategories == ItemCategories.Equipment)
            {
                _inventoryDisplayText += $"{kvP.Key.Identifier} x{kvP.Value} \n";
                GenerateItem(kvP.Key);
            }
        }

        Debug.LogWarning(string.Concat("Inventory \n ----- \n", _inventoryDisplayText));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            var ena = popupMenu.activeInHierarchy;
            popupMenu.SetActive(!ena);
        }
    }
}