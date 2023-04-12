using System;
using Character;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private Animator animator;
    [SerializeField] private InputController _inputController;
    
    private static readonly int XDirection = Animator.StringToHash("XDirection");
    private static readonly int YDirection = Animator.StringToHash("YDirection");
    private static readonly int Idle = Animator.StringToHash("Idle");
    
    private Vector2 _viewDirection;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    private void Update()
    {
        var idle = playerModel.Direction.x == 0 && playerModel.Direction.y == 0;
        animator.SetBool(Idle, idle);

        var lookAt = (_inputController.MousePosition - (Vector2)transform.position).normalized;
        
        var x = idle ? lookAt.x : playerModel.Direction.x;
        var y = idle ? lookAt.y : playerModel.Direction.y;

        animator.SetFloat(XDirection, x);
        animator.SetFloat(YDirection, y);
        
    }

}
