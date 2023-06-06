using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Scriptables/Item", order = 0)]
public abstract class ItemSO : ScriptableObject
{
    [SerializeField] protected int id;
    [SerializeField] protected string identifier;
    [SerializeField] protected string description;
    [SerializeField] protected Sprite icon;
    [SerializeField] protected ItemCategories itemCategories;
    [SerializeField] protected StatsSO stats;

    public int Id => id;
    public string Identifier => identifier;
    public string Description => description;
    public Sprite Icon => icon;
    public ItemCategories ItemCategories => itemCategories;
    public StatsSO Stats => stats;
}