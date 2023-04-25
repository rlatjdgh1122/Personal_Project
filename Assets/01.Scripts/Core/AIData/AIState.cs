using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour
{
    protected List<AIAction> actions;
    protected List<AITransition> transitions;

    private EnemyBrain brain;

    private void Awake()
    {

        actions = new();
        transitions = new();

        GetComponentsInChildren<AITransition>(transitions); //�� �ڽĿ� �ִ� ���̵� ���� �����ͼ� ����
        GetComponents<AIAction>(actions);//������ �پ��ִ� �׼� ���� �����ͼ� ����
    }
    public void SetUp(Transform parentTrm)
    {
        brain = parentTrm.GetComponent<EnemyBrain>();
        actions.ForEach(a => a.SetUp(parentTrm));
        transitions.ForEach(t => t.Setup(parentTrm));
    }
    public void UpdateState()
    {
        foreach (AIAction act in actions)
        {
            act.TakeAction();
        }
        foreach (AITransition t in transitions)
        {
            if (t.CanTransition())
            {
                brain.ChangeToState(t.transitionState);
            }
        }
    }
}
