using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    public float Radius = 1.5f;
    private int damage = 0;
    public void SetDamage(int value) { damage = value; }
    private void Start()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, Radius);
        foreach(var col in cols)
        {
            if (col.TryGetComponent<IDamageable>(out IDamageable component)) component.OnDamage(damage);
        }

        Destroy(gameObject,.6f);
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, Radius);
    }
}
