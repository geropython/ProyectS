using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Scriptables/Item", order = 0)]
public class ItemSO : ScriptableObject
{
    [SerializeField] private int id;
    [SerializeField] private string identifier;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;
    [SerializeField] private ItemCategories itemCategories;
    [SerializeField] private StatsSO stats;

    public int Id => id;
    public string Identifier => identifier;
    public string Description => description;
    public Sprite Icon => icon;
    public ItemCategories ItemCategories => itemCategories;
    public StatsSO Stats => stats;
}