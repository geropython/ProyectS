using System;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float speed;
    [Range(0, 10)] [SerializeField] private float attackTime;
    [SerializeField] private PlayerAttack playerAttack;

    private Vector2 _lookAtDirection;
    private Vector2 _forward;
    private bool _attacking;
    private bool _idle;
    
    public bool InventoryFull;

    public Action<Vector2> OnMove = delegate { };
    public Vector2 Direction { get; private set; }
    
    public bool Attacking => _attacking;
    public bool Idle => _idle;
    public float AttackTime => attackTime;
    public Vector2 Forward => _forward;
    public Vector2 LookAtDirection => _lookAtDirection;

    public void Move(Vector2 direction)
    {
        if (_attacking) return;
        Direction = direction * (speed * Time.deltaTime);
        transform.Translate(Direction);
        _idle = Direction is { x: 0, y: 0 };
    }

    public void LookAt(Vector2 direction)
    {
        _lookAtDirection = direction;
        _forward = (Vector2)transform.position + direction;
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
        Gizmos.DrawWireSphere((Vector3)_forward, .1f);
    }
}