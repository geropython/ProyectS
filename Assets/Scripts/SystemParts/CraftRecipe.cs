using UnityEngine;

public class CraftRecipe
{
    [SerializeField] private int itemResultId;
    [SerializeField] private int itemResultQuantity;
    [SerializeField] private int[] requiredItems;

    public int ItemResultId => itemResultId;
    public int ItemResultQuantity => itemResultQuantity;
    public int[] RequiredItems => requiredItems;

    public CraftRecipe(int itemResultId, int itemResultQuantity, int[] requiredItems)
    {
        this.itemResultId = itemResultId;
        this.requiredItems = requiredItems;
        this.itemResultQuantity = itemResultQuantity;
    }
}