using System.Collections.Generic;
using UnityEngine;

public class CraftDisplay : MonoBehaviour
{
    [SerializeField] private GameObject popupMenu;
    [SerializeField] private Transform contentContainer;
    [SerializeField] private UI_CraftContainer craftPrefab;

    private List<UI_CraftContainer> _itemsGenerated = new List<UI_CraftContainer>();

    public void Show()
    {
        FilterRecipes();
        popupMenu.SetActive(true);
    }

    public void Hide()
    {
        popupMenu.SetActive(false);
    }

    private void GenerateRecipeItem(CraftRecipeSO craftSo)
    {
        var go = Instantiate(craftPrefab, contentContainer, true);
        if (!_itemsGenerated.Contains(go))
        {
            _itemsGenerated.Add(go);
        }

        // configura los datos que se ven en el boton
        go.SetupButton(craftSo);

        //reset the item's scale -- this can get munged with UI prefabs
        go.transform.localScale = Vector2.one;
    }

    private void FilterRecipes()
    {
        foreach (var item in _itemsGenerated)
        {
            Destroy(item.gameObject);
        }

        _itemsGenerated.Clear();
        foreach (var recipe in GameManager.Instance.CraftDatabase.Recipes)
        {
            GenerateRecipeItem(recipe);
        }
    }
}