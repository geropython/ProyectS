using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class PickupSO : MonoBehaviour
{
    [SerializeField] private ItemSO item;
    [SerializeField] private int quantity;


    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerModel = other.GetComponent<PlayerModel>();
        // Confirmar que fue un jugador y que ese jugador no tenga el inventario lleno
        if (!playerModel || playerModel.InventoryFull) return;
        playerModel.PickupItemSO(item, quantity);
        // quizas cambiar esto por pool management
        Destroy(gameObject);
    }
}