using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new Recipe", menuName = "Scriptables/Craft Recipe", order = 0)]
public class CraftRecipeSO : ScriptableObject
{
    [Header("Item Result")] [Space(5)] [SerializeField]
    private ItemSO itemResult;

    [SerializeField] private int itemResultQuantity;

    [Header("Items Required to craft")] [Space(5)] [SerializeField]
    private List<ItemSO> itemsRequired;

    [SerializeField] private int[] itemsRequiredQuantity;
}