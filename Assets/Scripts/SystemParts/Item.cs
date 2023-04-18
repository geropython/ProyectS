using System.Collections.Generic;
using UnityEngine;

public class Item
{
    [SerializeField] private int id;
    [SerializeField] private string identifier;
    [SerializeField] private string description;
    [SerializeField] private Sprite icon;

    [SerializeField] private readonly Dictionary<string, int> stats = new();
    // public Enum Subcategory (Equipment,Crafting Material,Consumable) para poder filtrar maybe

    public int Id => id;
    public string Identifier => identifier;
    public string Description => description;
    public Sprite Icon => icon;
    public Dictionary<string, int> Stats => stats;

    public Item(int id, string identifier, string description, Sprite icon, Dictionary<string, int> stats)
    {
        this.id = id;
        this.identifier = identifier;
        this.description = description;
        this.icon = icon;
        this.stats = stats;
    }

    public Item(int id, string identifier, string description)
    {
        this.id = id;
        this.identifier = identifier;
        this.description = description;
    }
}