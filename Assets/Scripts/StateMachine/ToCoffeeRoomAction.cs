using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/To Coffee Room")]
public class ToCoffeeRoomAction : Action
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
