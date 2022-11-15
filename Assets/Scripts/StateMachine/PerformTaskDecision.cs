using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Perform Task")]
public class PerformTaskDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool isDoingTargetTask = controller.worker.GetTaskStatus();
        return isDoingTargetTask;
    }
}
