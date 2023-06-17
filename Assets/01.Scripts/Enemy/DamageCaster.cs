using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCaster : MonoBehaviour
{
    private int damage;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void SetDamage(int value)
    {
        damage = value;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (other.TryGetComponent<IDamageable>(out IDamageable component))
            {
                component.OnDamage(damage);
            }
        }
    }
}
