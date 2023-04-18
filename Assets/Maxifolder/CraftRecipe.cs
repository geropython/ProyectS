using UnityEngine;

public class CraftRecipe
{
    [SerializeField] private int itemResultId;
    [SerializeField] private int[] requiredItems;

    public int ItemResultId => itemResultId;
    public int[] RequiredItems => requiredItems;

    public CraftRecipe(int itemResultId, int[] requiredItems)
    {
        this.itemResultId = itemResultId;
        this.requiredItems = requiredItems;
    }
}