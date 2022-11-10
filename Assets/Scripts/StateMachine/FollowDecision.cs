using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Follow")]
public class FollowDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool hasFinishedDoingTargetTask = controller.worker.GetTaskStatus();
        return !hasFinishedDoingTargetTask;
    }
}
