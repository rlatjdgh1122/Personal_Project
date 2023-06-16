using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegularBullet : PoolableMono
{
    [SerializeField]
    private BulletData bulletData;
    private float timeToLive;

    private Rigidbody rigid;
    private bool isDead = false;
    private int p_damage = 0;
    private int e_damage = 0;

    private bool isEnemy = false;
    private TrailRenderer _tr;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        _tr = transform.Find("Trail").GetComponent<TrailRenderer>();

    }
    private void FixedUpdate()
    {
        timeToLive += Time.fixedDeltaTime;
        rigid.MovePosition(transform.position + transform.right * bulletData.speed * Time.fixedDeltaTime);

        if (timeToLive >= bulletData.lifeTime)
        {
            isDead = true;
            _tr.enabled = false;
            PoolManager.Instance.Push(this);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (isDead) return;

        HitCheck(collision);

        isDead = true;
        _tr.enabled = false;
        PoolManager.Instance.Push(this);
    }
    private void HitCheck(Collider collision)
    {
        if (collision.TryGetComponent<IDamageable>(out IDamageable health))
        {
            if (!isEnemy)
                health.OnDamage(p_damage);
            else
                health.OnDamage(e_damage);
        }
    }
    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }
    public void Set_P_Damage(int value)
    {
        p_damage = value;
    }
    public void Set_E_Damage(int value)
    {
        e_damage = value;
    }
    public override void Init()
    {
        isDead = false;
        _tr.enabled = true;
        timeToLive = 0;

    }
}
