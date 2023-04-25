using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    protected List<AIDecision> decisions;
    public AIState transitionState; //������ ����
    private void Awake()
    {
        decisions = new List<AIDecision>();
        GetComponents<AIDecision>(decisions); //��� ������� �����ͼ� ����Ʈ�� �����
    }
    public void Setup(Transform parentTrm)
    {
        decisions.ForEach(d => d.SetUp(parentTrm)); 
    }
    public bool CanTransition()
    {
        bool result = false;
        foreach(AIDecision d in decisions)
        {
            result = d.MakeADecison();
            if (d.IsReverse)
                result = !result;
            if (result == false)
                break;
        }
        return result;
    }
}
