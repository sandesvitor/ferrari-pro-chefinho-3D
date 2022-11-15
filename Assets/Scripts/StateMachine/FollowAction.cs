using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Follow")]
public class FollowAction : Action
{

    public override void Act(StateController controller)
    {
        Follow(controller);
    }

    private void Follow(StateController controller)
    {
        controller.worker.FollowMouse();
    }
}
