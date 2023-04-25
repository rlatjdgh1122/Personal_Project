using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyBrain : PoolableMono
{
    public Transform Target;
    public UnityEvent<Vector2> OnMovementKeyPress;
    public UnityEvent<Vector2> OnPointerPositionChanged;

    public UnityEvent OnResetPool = null;
    public UnityEvent OnAttacking = null;
    //공격은 나중에
    public Transform BasePosition;
    public AIState currentSeason;

    [SerializeField]
    private bool isActive = false;
    private void Start()
    {
        Target = GameManager.Instance.playerPos;
        currentSeason?.SetUp(transform);
    }
    public void ChangeToState(AIState nextState)
    {
        currentSeason = nextState;
        currentSeason?.SetUp(transform); //최적화 필요한 부분
    }
    public void Update()
    {
        if (isActive == false) return;

        if (Target == null)
        {
            OnMovementKeyPress?.Invoke(Vector3.zero);
        }
        else
        {
            currentSeason.UpdateState();
        }
    }
    public override void Init()
    {
        isActive = false;
        OnResetPool?.Invoke();
    }
    public void GotoPool()
    {
        PoolManager.Instance.Push(this);
    }
}
