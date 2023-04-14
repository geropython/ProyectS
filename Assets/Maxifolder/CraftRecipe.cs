using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Craft Recipe", fileName = "new craftRecipe")]
public class CraftRecipe : ScriptableObject
{
    public int[] requiredItems;
    public int itemResultId; 
}