using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int id;
    public string name;
    public string description;
    public Sprite icon;
    public Dictionary<string,int> stats = new Dictionary<string,int>();
    // public Enum Subcategory (Equipment,Crafting Material,Consumable) para poder filtrar 

    public virtual Constructor (int id,string name, string description, Sprite icon, Dictionary<string,int> stats)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.icon = icon;
        this.stats = stats;
    }
}