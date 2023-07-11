using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float speed;
    [Range(0, 10)] [SerializeField] private float attackTime;
    [SerializeField] private PlayerAttack playerAttack;
    private Vector2 forward;

    private bool _attacking;
    
    public bool InventoryFull;

    public Action<Vector2> OnMove = delegate { };
    public Vector2 Direction { get; private set; }
    
    public bool Attacking => _attacking;
    public float AttackTime => attackTime;
    public Vector2 Forward => forward;
    
    private void Update()
    {
        transform.Translate(Direction);
        Direction = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        if (_attacking) return;
        Direction = direction * (speed * Time.deltaTime);
    }

    public void LookAt(Vector2 direction)
    {
        forward = (Vector2)transform.position + direction;
    }

    public void Attack()
    {
        playerAttack.Attack();
        _attacking = true;
        Invoke(nameof(StopAttacking), attackTime);
    }

    public void StopAttacking()
    {
        _attacking = false;
    }

    public void PickupItemSO(ItemSO itemSO, int quantity)
    {
        // usa el id para leer la database y asi agregar el item a su inventario
        ItemSO item = GameManager.Instance.ItemDatabase.GetItemSO(itemSO);
        if (item != null)
        {
            GameManager.Instance.PlayerInventory.AddItemSO(item, quantity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere((Vector3)forward, .1f);
    }
}