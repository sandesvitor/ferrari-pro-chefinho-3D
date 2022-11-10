using UnityEngine;

public class StateController : MonoBehaviour
{
    public State currentState;
    public WorkerController worker;
    public State remainState;

    [SerializeField] private bool aiActive = true;

    void Awake()
    {
        worker = this.GetComponent<WorkerController>();
    }

    void Update()
    {
        if (!aiActive)
            return;
        currentState.UpdateState(this);
    }

    void OnDrawGizmos()
    {
        if (currentState != null)
        {
            Gizmos.color = currentState.sceneGizmoColor;
            Gizmos.DrawSphere(this.transform.position, 2f);
        }
    }

    public void TransitionToState(State nextState)
    {
        if (nextState != remainState)
        {
            currentState = nextState;
        }
    }
}
