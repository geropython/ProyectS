using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_CraftContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Button")] [Space(5)] [SerializeField]
    private Image buttonIcon;

    [SerializeField] private TextMeshProUGUI buttonName;

    private CraftRecipeSO _craftData;

    public void SetupButton(CraftRecipeSO recipe)
    {
        buttonIcon.sprite = recipe.ItemResult.Icon;
        buttonName.text = recipe.ItemResult.Identifier;
        _craftData = recipe;
    }

    private void SetupInfo()
    {
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}