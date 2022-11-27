using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Decisions/Stay Idle")]
public class StayIdleDecision : Decision
{
    public override bool Decide(StateController controller)
    {
        bool isDoingTargetTask = controller.worker.GetIdleStatus();
        return true;
    }
}
