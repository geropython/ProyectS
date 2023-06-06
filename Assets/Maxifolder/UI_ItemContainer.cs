using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_ItemContainer : MonoBehaviour
{
    [SerializeField] private Image buttonIcon;
    [SerializeField] private TextMeshProUGUI buttonName;

    public void SetupButton(Sprite itemIcon, string itemName)
    {
        buttonIcon.sprite = itemIcon;
        buttonName.text = itemName;
    }
}