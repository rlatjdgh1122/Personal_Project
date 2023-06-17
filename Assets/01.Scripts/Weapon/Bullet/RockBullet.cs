using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBullet : MonoBehaviour
{
    [SerializeField]
    private GameObject broken_stone;

    private Rigidbody _rigid;
    private MeshCollider _mesh;
    private int damage;

    private bool isTriggerCheck = false;
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
        _mesh = GetComponent<MeshCollider>();

        _rigid.useGravity = false;
        _mesh.isTrigger = true;
        isTriggerCheck = false;
    }

    public void Throw()
    {
        isTriggerCheck = true;
        _mesh.isTrigger = false;
        _rigid.useGravity = true;

        _rigid.AddForce((transform.root.Find("Controller").forward + (Vector3.up * .1f))
            * Random.Range(10, 15), ForceMode.Impulse);
    }
    public void SetDamage(int value)
    {
        damage = value;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (isTriggerCheck)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (collision.collider.TryGetComponent<IDamageable>(out IDamageable damageable))
                {
                    damageable.OnDamage(damage);
                }
            }
            Destroy(this.gameObject);
            GameObject b = Instantiate(broken_stone, transform.position + Vector3.up * 3, Quaternion.identity);
            Rigidbody[] rigids = b.GetComponentsInChildren<Rigidbody>();
            foreach (var r in rigids)
            {
                r.AddForce(transform.forward * Random.Range(5, 11), ForceMode.Impulse);
            }
            Destroy(b, 3f);
        }
    }
    private void Update()
    {
        Destroy(this.gameObject, 5f);
    }
}
