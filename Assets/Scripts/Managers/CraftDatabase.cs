using System.Collections.Generic;
using UnityEngine;

public class CraftDatabase : MonoBehaviour
{
    [SerializeField] private List<CraftRecipeSO> recipesSODatabase = new();

    public CraftRecipeSO GetRecipeSO(ItemSO result)
    {
        return recipesSODatabase.Find(recipe => recipe.ItemResult == result);
    }

    public CraftRecipeSO GetRecipeSO(int id)
    {
        return recipesSODatabase.Find(recipe => recipe.ItemResult.Id == id);
    }
}