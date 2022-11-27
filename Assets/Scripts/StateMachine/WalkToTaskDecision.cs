using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Walk To Task")]
public class WalkToTaskDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool isDoingTargetTask = controller.worker.GetWalkToTaskStatus();
        return true;
    }
}
