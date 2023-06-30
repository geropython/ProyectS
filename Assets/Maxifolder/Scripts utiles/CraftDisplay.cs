using UnityEngine;

public class CraftDisplay : MonoBehaviour
{
    [SerializeField] private GameObject popupMenu;

    public void Show()
    {
        popupMenu.SetActive(true);
    }

    public void Hide()
    {
        popupMenu.SetActive(false);
    }
}