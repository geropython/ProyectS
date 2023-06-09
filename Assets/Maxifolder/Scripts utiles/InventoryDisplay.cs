using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private GameObject popupMenu;
    [SerializeField] private Transform contentContainer;
    [SerializeField] private UI_ItemContainer itemPrefab;
    [SerializeField] private TextMeshProUGUI filterName;

    [Header("Info UI")] [Space(5)] [SerializeField]
    private TextMeshProUGUI itemIdentifier;

    [SerializeField] private TextMeshProUGUI itemCategory;
    [SerializeField] private TextMeshProUGUI itemDescription;

    private List<UI_ItemContainer> _itemsGenerated = new List<UI_ItemContainer>();
    private int _currentFilter;
    private int _lengthFilter;

    private void Awake()
    {
        _lengthFilter = Enum.GetValues(typeof(ItemCategories)).Length - 1;
    }

    private void GenerateInventoryItem(ItemSO itemSo, int itemAmount)
    {
        var go = Instantiate(itemPrefab, contentContainer, true);
        if (!_itemsGenerated.Contains(go))
        {
            go.OnInteraction += ShowDetails;
            _itemsGenerated.Add(go);
        }

        // configura los datos que se ven en el boton
        go.SetupButton(itemSo, itemAmount);

        //reset the item's scale -- this can get munged with UI prefabs
        go.transform.localScale = Vector2.one;
    }

    [ContextMenu("NextFilter")]
    public void NextFilter()
    {
        _currentFilter++;
        if (_currentFilter > _lengthFilter)
        {
            _currentFilter = 0;
        }

        UpdateFilterName();
        FilterInventory();
    }

    [ContextMenu("PrevFilter")]
    public void PreviousFilter()
    {
        _currentFilter--;
        if (_currentFilter < 0)
        {
            _currentFilter = _lengthFilter;
        }

        UpdateFilterName();
        FilterInventory();
    }

    private void FilterInventory()
    {
        foreach (var item in _itemsGenerated)
        {
            item.OnInteraction -= ShowDetails;
            Destroy(item.gameObject);
        }

        _itemsGenerated.Clear();
        foreach (var kvP in GameManager.Instance.PlayerInventory.PlayerInventoryDicSO)
        {
            if ((ItemCategories)_currentFilter == ItemCategories.All)
            {
                GenerateInventoryItem(kvP.Key, kvP.Value);
            }
            else if (kvP.Key.ItemCategories == (ItemCategories)_currentFilter)
            {
                GenerateInventoryItem(kvP.Key, kvP.Value);
            }
        }
    }

    private void UpdateFilterName()
    {
        var eName = (ItemCategories)_currentFilter;
        filterName.text = eName.ToString();
    }

    public void Show()
    {
        FilterInventory();
        popupMenu.SetActive(true);
    }

    public void Hide()
    {
        popupMenu.SetActive(false);
    }

    private void ShowDetails(ItemSO item)
    {
        itemIdentifier.text = item.Identifier;
        itemCategory.text = item.ItemCategories.ToString();
        itemDescription.text = item.Description;
    }
}