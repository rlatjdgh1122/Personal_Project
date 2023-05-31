using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            if(collision.transform.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            {
                playerMovement.isWall = true;
            }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            if (collision.transform.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            {
                playerMovement.isWall = false;
            }
        }
    }
}
