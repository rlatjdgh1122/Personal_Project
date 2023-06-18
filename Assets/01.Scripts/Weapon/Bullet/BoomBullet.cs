using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class BoomBullet : PoolableMono
{
    public BulletData bulletData;
    private Rigidbody _rigid;
    private float time = 0;
    private int damage = 0;

    private Vector3 dir = Vector3.zero;
    public void SetDamage(int value)
    {
        damage = value;
    }
    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        _rigid.AddForce(dir * bulletData.speed + Vector3.up, ForceMode.Impulse);
    }
    void OnEnable()
    {
        _rigid.AddForce(dir * bulletData.speed + Vector3.up, ForceMode.Impulse);
    }
    void Update()
    {
        time += Time.deltaTime;
        if (time >= bulletData.lifeTime)
        {
            GameObject b = Instantiate(bulletData.hitParticle, transform.position, Quaternion.identity);
            if (b.TryGetComponent<Boom>(out Boom boom)) { boom.SetDamage(damage); }
            PoolManager.Instance.Push(this);
        }
    }
    public void SetPosition(Vector3 position , Vector3 value)
    {
        transform.position = position;
        dir = value;
    }
    public override void Init()
    {
        time = 0;
        dir = Vector3.zero;
    }

}
