using System.Collections.Generic;
using UnityEngine;

public class CraftDatabase : MonoBehaviour
{
    private List<CraftRecipe> _recipesDatabase = new();

    private void Awake()
    {
        BuildRecipeDatabase();
    }

    // Buscar receta por el id del item que resulta
    public CraftRecipe GetRecipe(int id)
    {
        return _recipesDatabase.Find(recipe => recipe.ItemResultId == id);
    }

    private void BuildRecipeDatabase()
    {
        _recipesDatabase = new List<CraftRecipe>()
        {
            new(3, 1, new[] { 1, 1, 1, 2, 2 }),
        };
    }
}