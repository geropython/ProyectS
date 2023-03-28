using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterModel : MonoBehaviour
{

    [Range(0, 10)] [SerializeField] private float speed;
    
    public void Move(Vector2 direction)
    {
        transform.Translate(direction * (speed * Time.deltaTime));
    }
    
}
