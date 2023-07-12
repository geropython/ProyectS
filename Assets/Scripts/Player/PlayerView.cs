using System;
using Character;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private Animator animator;
    [SerializeField] private InputController _inputController;
    
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Attack = Animator.StringToHash("Attack");
    
    private Vector2 _viewDirection;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        animator.SetBool(Idle, playerModel.Idle);

        var lookAt = (_inputController.MousePosition - (Vector2)transform.position).normalized;
        
        var x = playerModel.Idle ? playerModel.LookAtDirection.x : playerModel.Direction.x;
        var y = playerModel.Idle ? playerModel.LookAtDirection.y : playerModel.Direction.y;

        animator.SetFloat("XDirection", x);
        animator.SetFloat("YDirection", y);
        
        animator.SetBool(Attack, playerModel.Attacking);
    }

}
