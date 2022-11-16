using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Move To Task")]
public class MoveToTaskDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool isDoingTargetTask = controller.worker.GetTaskStatus();
        return isDoingTargetTask;
    }
}
