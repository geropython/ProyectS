using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string identifier;
    public string description;
    public Sprite icon;
    public Dictionary<string,int> stats = new Dictionary<string,int>();
    // public Enum Subcategory (Equipment,Crafting Material,Consumable) para poder filtrar 

    public Item (int id,string identifier, string description, Sprite icon, Dictionary<string,int> stats)
    {
        this.id = id;
        this.identifier = identifier;
        this.description = description;
        this.icon = icon;
        this.stats = stats;
    }
}