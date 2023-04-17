using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();
    private void Awake()
    {
        BuildItemDatabase();
    }
    public Item GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }
    public Item GetItem(string identifier)
    {
        return items.Find(item => item.identifier == identifier);
    }
    private void BuildItemDatabase()
    {
        items = new List<Item>(){};
    }
}