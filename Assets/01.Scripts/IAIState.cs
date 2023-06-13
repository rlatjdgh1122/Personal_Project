using UnityEngine;

public interface IAIState
{
    public void OnEnterState();
    public void OnExitState();
    public bool UpdateState();
    public void SetUp(Transform agentTransform);

}
