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

        GetComponentsInChildren<AITransition>(transitions); //내 자식에 있는 전이들 전부 가져와서 실행
        GetComponents<AIAction>(actions);//나한테 붙어있는 액션 전부 가져와서 실행
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
