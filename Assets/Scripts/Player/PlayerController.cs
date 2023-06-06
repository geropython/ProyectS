using System;
using UnityEngine;

namespace Character
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private InputController inputController;
        [SerializeField] private PlayerModel playerModel;

        private void Start()
        {
            inputController.PrimaryFireEventStarted += Attack;
        }

        private void Update()
        {
            playerModel.Move(inputController.Movement);
        }

        private void Attack()
        {
            playerModel.Attack();
        }
    }
}
