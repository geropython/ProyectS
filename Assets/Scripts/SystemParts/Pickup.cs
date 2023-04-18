using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pickup : MonoBehaviour
{
    public int itemId;
    public int quantity;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerModel = other.GetComponent<PlayerModel>();
        // Confirmar que fue un jugador y que ese jugador no tenga el inventario lleno
        if (!playerModel || playerModel.InventoryFull) return;
        playerModel.PickupItem(itemId, quantity);
        // quizas cambiar esto por pool management
        Destroy(gameObject);
    }
}