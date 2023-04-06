using System;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    public Action<Vector2> OnMove = delegate(Vector2 vector2) {  };
    
    [Range(0, 10)] [SerializeField] private float speed;

    private Vector2 _direction;
    public Vector2 Direction => _direction;

    private void Update()
    {
        transform.Translate(_direction);
        _direction = Vector2.zero;
    }

    public void Move(Vector2 direction)
    {
        _direction = direction * (speed * Time.deltaTime);
    }

}
