using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UI_ItemContainer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Button")] [Space(5)] [SerializeField]
    private Image buttonIcon;

    [SerializeField] private TextMeshProUGUI buttonName;
    [SerializeField] private TextMeshProUGUI buttonAmount;

    [Header("Info")] [Space(5)] [SerializeField]
    private TextMeshProUGUI _type;

    private ItemSO _itemData;

    public void SetupButton(ItemSO item, int itemAmount)
    {
        buttonIcon.sprite = item.Icon;
        buttonName.text = item.Identifier;
        buttonAmount.text = itemAmount.ToString();
        _itemData = item;
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