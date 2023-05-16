using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Pickup : MonoBehaviour
{
    [SerializeField] private ItemSO item;
    [SerializeField] private int quantity;
    [SerializeField] private float lifetime;

    private void Awake()
    {
        Invoke(nameof(Destruction), lifetime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerModel = other.GetComponent<PlayerModel>();
        // Confirmar que fue un jugador y que ese jugador no tenga el inventario lleno
        if (!playerModel || playerModel.InventoryFull) return;
        playerModel.PickupItemSO(item, quantity);
        // quizas cambiar esto por pool management
        Destruction();
    }

    public void Setup(ItemSO itemRef, int amount)
    {
        item = itemRef;
        quantity = amount;
    }

    private void Destruction()
    {
        CancelInvoke();
        Destroy(gameObject);
    }
}