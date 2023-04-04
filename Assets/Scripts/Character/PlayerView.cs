using System;
using Character;
using UnityEngine;

public class PlayerView : MonoBehaviour
{

    [SerializeField] private PlayerModel playerModel;
    [SerializeField] private Animator animator;
    
    private static readonly int XDirection = Animator.StringToHash("XDirection");
    private static readonly int YDirection = Animator.StringToHash("YDirection");
    private static readonly int Idle = Animator.StringToHash("Idle");
    
    private Vector2 _viewDirection;
    

    private void Update()
    {
        var idle = playerModel.Direction.x == 0 && playerModel.Direction.y == 0;
        animator.SetBool(Idle, idle);
        if (idle) return;
        
        animator.SetFloat(XDirection, playerModel.Direction.x);
        animator.SetFloat(YDirection, playerModel.Direction.y);
        
    }

}
