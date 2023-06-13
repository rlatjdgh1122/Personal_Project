using Core;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : EnemyAnimationController
{
    private EnemyController _enemyController;
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
    }
    private void Update()
    {
        State();
    }

    public void SetSpeed(float speed)
    {
        _agent.speed = speed;
    }
    public bool CheckIsArrived()
    {
        return (_agent.pathPending == false && _agent.remainingDistance <= _agent.stoppingDistance);
    }

    public void State()
    {
        if (_isActive)
        {
            if (IsRotate)
            {
                Quaternion rot = Quaternion.LookRotation(GameManager.Instance.playerPos.position, Vector3.up);
                transform.rotation = rot;
            }
            if (IsMove)
            {
                _agent.SetDestination(GameManager.Instance.playerPos.position);
            }
        }
       
    }
}