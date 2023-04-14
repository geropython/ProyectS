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
    public Item GetItem(string name)
    {
        return items.Find(item => item.name == name);
    }
    private void BuildItemDatabase()
    {
        items = new List<Item>()
        {
            new Item(1, "Stone", "A chunk of stone.", 
            new Dictionary<string, int> 
            {
                { "Power", 1 },
                { "Defence", 1 }
            }),
            new Item(2, "Wood", "This was once a tree.",
            new Dictionary<string, int> 
            {
                { "Value", 1 }
            }),
            new Item(3, "Rusty Pipe", "A pipe that has seen better days.",
            new Dictionary<string, int> 
            {
                { "Power", 3 },
                { "Defence", 2 }
            })
        };
    }
}