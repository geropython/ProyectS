using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftZone : MonoBehaviour
{
    [SerializeField] private int itemToCraftId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        var playerModel = other.GetComponent<PlayerModel>();
        if (playerModel)
        {
        }
    }

    private void Craft()
    {
    }
}