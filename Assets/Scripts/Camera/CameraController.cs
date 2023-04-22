using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform character;
    [SerializeField] private InputController _inputController;
    
    [Range(0f, 10f)] [SerializeField] private float followSpeed;
    [Range(0f, 10f)] [SerializeField] private float maxMouseDistanceFromPlayer;
    [Range(0f, 10f)] [SerializeField] private float minMouseDistanceFromPlayer;
    
    private Vector2 _midPoint;
    
    void Start()
    {
        if (character == null)
        {
            character = FindObjectOfType<CharacterController>().transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 startPosition = transform.position;

        var distanceFromPlayer = Vector2.Distance(_inputController.MousePosition, character.transform.position);

        var mouseDirection = (_inputController.MousePosition - (Vector2)character.transform.position).normalized;

        //Debug.Log(mouseDirection);
        Vector2 followPosition = new Vector2();

        if (distanceFromPlayer <= minMouseDistanceFromPlayer) //Snap directly to player
        {
            followPosition = character.transform.position;
        } 
        else if (distanceFromPlayer > maxMouseDistanceFromPlayer) //Don't go any further
        {
            followPosition = (Vector2)character.transform.position + (mouseDirection * maxMouseDistanceFromPlayer);
        }
        else
        {
            followPosition = _inputController.MousePosition;
        }

        // Debug.Log($"distance between player and mouse:{distanceFromPlayer}");
        
        _midPoint = (followPosition + (Vector2)character.transform.position) / 2f;

        var newPosition = (Vector3)Vector2.Lerp(startPosition,  _midPoint,
            followSpeed * Time.deltaTime);

        newPosition.z = -10;

        transform.position = newPosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(_midPoint, 1);
    }
}
