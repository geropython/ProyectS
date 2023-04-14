using Unity Engine;

public class CraftDatabase : MonoBehaviour
{
    public List<CraftRecipe> recipes = new List<CraftRecipe>();
    private void Awake()
    {
        BuildRecipeDatabase();
    }
    public CraftRecipe GetRecipe(int id)
    {
        return recipes.Find(recipe => recipe.itemResultId == id);
    }
    private void BuildRecipeDatabase()
    {
        // recipe=getcomponents<craftrecipe>
        // recipes.add(recipe);
    }
}