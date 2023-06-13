using Core;
using System;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : EnemyAnimationController
{
    private EnemyController _enemyController;
    private Rigidbody _rigid;
    private NavMeshAgent _agent;

    private bool _isActive = true;
    private bool _isRotate = true;
    private bool _isMove = true;
    public bool IsActive { get { return _isActive; } set { _isActive = value; } }
    public bool IsRotate { get { return _isRotate; } set { _isRotate = value; } }
    public bool IsMove { get { return _isMove; } set { _isMove = value; } }
    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<EnemyController>();
        _rigid = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        State();
    }
    private void FixedUpdate()
    {
        FreezeVelosity();
    }

    private void FreezeVelosity()
    {
        _rigid.velocity = Vector3.zero;
        _rigid.angularVelocity = Vector3.zero;
    }

    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
    public void State()
    {
        if (_isActive)
        {
            if (IsRotate)
            {
                transform.rotation = Quaternion.LookRotation(GameManager.Instance.playerPos.position);
            }
            if (IsMove)
            {
                _agent.SetDestination(GameManager.Instance.playerPos.position);
            }
            else _agent.SetDestination(transform.position);
        }
       
    }
}