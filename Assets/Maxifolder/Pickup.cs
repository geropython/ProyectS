using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int itemId;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // check if player
        // check if inventory full
        // player.pickupItem(itemId)
        // Destroy();        
    }      

}