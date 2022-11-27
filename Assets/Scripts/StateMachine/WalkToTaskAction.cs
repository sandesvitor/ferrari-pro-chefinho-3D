using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Walk To Task Room")]
public class WalkToTaskAction : Action
{
    public override void Act(StateController controller)
    {
        controller.worker.WalkToTaskAction();
    }
}

