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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead) return;
        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            HitObstacle(collision);
        }
        if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            HitEnemy(collision);
        }
        isDead = true;
        PoolManager.Instance.Push(this);
    }
    private void HitObstacle(Collider2D collision)
    {
    }
    private void HitEnemy(Collider2D collision)
    {
    }
    public void SetPositionAndRotation(Vector3 pos, Quaternion rot)
    {
        transform.SetPositionAndRotation(pos, rot);
    }
    public override void Init()
    {
        isDead = false;
        timeToLive = 0;

    }
}
