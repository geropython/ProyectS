using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform character;

    [Range(0f, 1f)] [SerializeField] private float followSpeed;
    
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

        var newPosition = (Vector3)Vector2.Lerp(startPosition, character.transform.position,
            followSpeed * Time.deltaTime);

        newPosition.z = -10;

        transform.position = newPosition;
    }
}
