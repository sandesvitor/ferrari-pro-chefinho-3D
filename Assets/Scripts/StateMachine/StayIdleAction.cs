using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Stay Idle")]
public class StayIdleAction : Action
{

    public override void Act(StateController controller)
    {
        controller.worker.StayIdleAction();
    }
}
