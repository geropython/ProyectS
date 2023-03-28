using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private InputController inputController;
    [SerializeField] private CharacterModel characterModel;

    private void Update()
    {
        characterModel.Move(inputController.Movement);
    }
}
