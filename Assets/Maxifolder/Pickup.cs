using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pickup : MonoBehaviour
{
    public int itemId;
    public int quantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerModel = other.GetComponent<PlayerModel>();
        if (!playerModel || playerModel.InventoryFull) return;
        playerModel.PickupItem(itemId, quantity);
        GameManager.Instance.PlayerInventory.CheckItem(itemId);
        // quizas cambiar esto por pool management
        Destroy(gameObject);
    }
}