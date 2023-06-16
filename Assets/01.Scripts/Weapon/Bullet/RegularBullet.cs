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
    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        timeToLive += Time.fixedDeltaTime;
        rigid.MovePosition(transform.position + transform.right * bulletData.speed * Time.fixedDeltaTime);

        if (timeToLive >= bulletData.lifeTime)
        {
            isDead = true;
            PoolManager.Instance.Push(this);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (isDead) return;

        HitCheck(collision);

        isDead = true;
        PoolManager.Instance.Push(this);
    }
    private void HitCheck(Collider collision)
    {
        if (collision.TryGetComponent<EnemyHealth>(out EnemyHealth enemyHealth))
        {
            enemyHealth.OnDamage(p_damage, Vector3.zero, Vector3.zero);
        }
        if (collision.TryGetComponent<PlayerHealth>(out PlayerHealth playerHealth))
        {
            playerHealth.OnDamage(p_damage);
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
        timeToLive = 0;

    }
}
