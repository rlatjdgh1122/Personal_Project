using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public CommonAIState _currentState;
    public EnemySoData EnemySoData;

    private List<AITransition> _anyTransitions = new List<AITransition>();
    public List<AITransition> AnyTransitions => _anyTransitions;

    [HideInInspector]
    public Transform _targetTrm;

    private AIActionData _actionData;
    private EnemyHealth _enemyHealth;
    private DamageCaster _damageCaster;

    private void Awake()
    {
        List<CommonAIState> states = new List<CommonAIState>();
        transform.Find("AI").GetComponentsInChildren<CommonAIState>(states);

        states.ForEach(s => s.SetUp(transform));

        _actionData = transform.Find("AI").GetComponent<AIActionData>();
        _enemyHealth = GetComponent<EnemyHealth>();
        _damageCaster = transform.Find("DamageCaster").GetComponent<DamageCaster>();

        Transform anyTranTrm = transform.Find("AI/AnyTransitions");
        if (anyTranTrm != null)
        {
            anyTranTrm.GetComponentsInChildren<AITransition>(_anyTransitions);
            _anyTransitions.ForEach(t => t.SetUp(transform));   
        }
    }
    private void Start()
    {
        _targetTrm = GameManager.Instance.playerPos;
        ChangeState(_currentState);

        _enemyHealth.SetMaxHP(EnemySoData.hp);
        _damageCaster.SetDamage(EnemySoData.damage);
    }

    public void ChangeState(CommonAIState nextState)
    {
        _currentState?.OnExitState();
        _currentState = nextState;
        _currentState?.OnEnterState();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) _enemyHealth.OnDamage(10,Vector3.zero, Vector3.zero);

        if (_enemyHealth.IsDead) return;
        _currentState?.UpdateState();
    }

}
