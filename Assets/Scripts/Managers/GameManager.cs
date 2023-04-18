using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton

    public static GameManager Instance;

    private void MakeSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    #endregion

    public ItemDatabase ItemDatabase { get; private set; }
    public CraftDatabase CraftDatabase { get; private set; }
    public PlayerInventory PlayerInventory { get; private set; }

    private void Awake()
    {
        MakeSingleton();
        LoadComponents();
    }

    private void LoadComponents()
    {
        ItemDatabase = GetComponent<ItemDatabase>();
        CraftDatabase = GetComponent<CraftDatabase>();
        PlayerInventory = GetComponent<PlayerInventory>();
    }
}