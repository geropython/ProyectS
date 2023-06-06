using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float speed;
    public bool InventoryFull;

    public Action<Vector2> OnMove = delegate { };
    public Vector2 Direction { get; private set; }

    private void Update()
    {
        transform.Translate(Direction);
        Direction = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        Direction = direction * (speed * Time.deltaTime);
    }

    public void PickupItemSO(ItemSO itemSO, int quantity)
    {
        if (itemSO != null)
        {
            GameManager.Instance.PlayerInventory.AddItemSO(itemSO, quantity);
        }
    }

    public void DropItemSO(ItemSO itemSo, int quantity)
    {
        GameManager.Instance.PlayerInventory.RemoveItemSO(itemSo, quantity);
    }
}