using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSM : MonoBehaviour
{
    private EnemyState _currentState;

    private void Start()
    {
        // Set the initial state
        ChangeState(new IdleState(this));
    }
    private void Update()
    {
        // Update the current state
        _currentState.Update();
    }
    public void ChangeState(EnemyState newState)
    {
        // Exit the current state
        if (_currentState != null)
        {
            _currentState.Exit();
        }

        // Enter the new state
        _currentState = newState;
        _currentState.Enter();
    }
}