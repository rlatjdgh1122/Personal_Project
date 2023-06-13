using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody[] rigid;
        rigid = collision.gameObject.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rigid)
        {
            rb.AddExplosionForce(1000,transform.position,10);
        }
        Destroy(collision.gameObject, 1);
    }
}
