using Core;
using System;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : EnemyAnimationController
{
    private EnemyController _enemyController;
    private Rigidbody _rigid;
    private NavMeshAgent _agent;
    private Transform target;

    private bool _isRotate = true;
    private bool _isMove = true;
    private bool _isLookTarget = true;
    public bool IsRotate { get { return _isRotate; } set { _isRotate = value; } }
    public bool IsMove { get { return _isMove; } set { _isMove = value; } }
    public bool IsLookTarget { get { return _isLookTarget; } set { _isLookTarget = value; } }
    protected override void Awake()
    {
        base.Awake();
        _agent = GetComponent<NavMeshAgent>();
        _enemyController = GetComponent<EnemyController>();
        _rigid = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        target = GameManager.Instance.playerPos;
        _agent.updateRotation = true;
        _agent.autoBraking = true;
    }
    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
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

    public void State()
    {
        Vector3 direction = target.position - transform.position;
        direction.y = 0;

        Vector3 frontVector = transform.forward;
        float angle = Vector3.Angle(frontVector, direction);

        if (angle >= 5)
        {
            IsLookTarget = false;
        }
        else IsLookTarget = true;

        if (IsRotate)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _enemyController.EnemySoData.rotationSpeed * Time.deltaTime);
        }
        if (IsMove)
        {
            _agent.SetDestination(GameManager.Instance.playerPos.position);
        }
        else if (IsMove == false)
        {
            _agent.velocity = Vector3.zero;
            _agent.SetDestination(transform.position);
        }
    }
}