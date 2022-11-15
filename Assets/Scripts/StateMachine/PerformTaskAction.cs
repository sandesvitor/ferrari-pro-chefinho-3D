using UnityEngine;

[CreateAssetMenu (menuName = "PluggableAI/Actions/Perform Task")]
public class PerformTaskAction : Action
{

    public override void Act(StateController controller)
    {
        PerformTask(controller);
    }

    private void PerformTask(StateController controller)
    {
       controller.worker.StopFollowingMouse();
    }
}
