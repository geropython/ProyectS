using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineOfSight : MonoBehaviour
{
    //LOS Variables:
    [SerializeField] public Transform player;
    [SerializeField] private float maxDistance = 10f;
    [SerializeField] private LayerMask obstacleMask;
    private bool playerDetected = false;
    private void Update()
    {
        bool canSeePlayer = CanSeePlayer();

        if (canSeePlayer && !playerDetected)
        {
            print("Player in sight");
            playerDetected = true;
        }
        else if (!canSeePlayer && playerDetected)
        {
            print("PLayer out of Sight.");
            playerDetected = false;
        }
    }
    public bool CanSeePlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > maxDistance)
        {
            return false;
        }

        var transform1 = transform;
        var position = transform1.position;
        Vector2 direction = player.position - position;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, maxDistance, obstacleMask);

        if (hit.collider != null && hit.collider.CompareTag("PlayerDetection"))
        {
            return true;
        }

        return false;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, maxDistance);
    }
}