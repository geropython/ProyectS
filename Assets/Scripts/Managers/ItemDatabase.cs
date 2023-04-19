using System.Collections.Generic;
using UnityEngine;

public enum ItemCategories
{
    Equipment = 0,
    Consumable = 1,
    Material = 2,
}

public class ItemDatabase : MonoBehaviour
{
    private List<Item> _itemsDatabase = new();

    private void Awake()
    {
        BuildItemDatabase();
    }

    // Busca item por su id propio
    public Item GetItem(int id)
    {
        return _itemsDatabase.Find(item => item.Id == id);
    }

    // Busca item por su nombre propio (tiene que estar escrito exacto)
    public Item GetItem(string identifier)
    {
        return _itemsDatabase.Find(item => item.Identifier == identifier);
    }

    private void BuildItemDatabase()
    {
        _itemsDatabase = new List<Item>()
        {
            new(0, "Empty", "Empty Item"),
            new(1, "Rock", "A rock."),
            new(2, "Wooden Stick", "A stick made of wood"),
            new(3, "Rock Axe", "An Axe made of rock with a wooden handle"),
        };
    }
}