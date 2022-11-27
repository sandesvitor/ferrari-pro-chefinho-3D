using UnityEngine;
using UnityEngine.AI;

public class WorkerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera cam;
    [SerializeField] private bool isWorkerIdle = true;
    [SerializeField] private bool isWorkerWalkingToTask = false;
    [SerializeField] private bool isWorkerDoingTask = false;
    [SerializeField] private Vector2 speedRange = new Vector2(5f, 10f);
    
    public int id;

    private Transform destination;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        agent.speed = Random.Range(speedRange.x, speedRange.y);

        destination = this.transform;

        GameEventSystem.current.OnWorkerSentToEnterTaskRoom += WalkToTask;
    }

    void Update()
    {
        HandlePathFindingMovement(destination);
    }

    private void HandlePathFindingMovement(Transform transform)
    {
        agent.SetDestination(transform.position);
    }

    private void WalkToTask(int workerId, Waypoint waypoint)
    {
        if (workerId == this.id)
        {
            Debug.Log($"Worker ID [{workerId}], Waypoint [{waypoint.gameObject.name}]");
            destination = waypoint.transform;
        }
    }

    public void WalkToTaskAction()
    {
        isWorkerIdle = false;
        isWorkerWalkingToTask = true;
    }

    public void StayIdleAction()
    {
        destination = this.transform;
        isWorkerIdle = true;
        isWorkerWalkingToTask = false;
    }

    public bool GetWalkToTaskStatus()
    {
        return isWorkerWalkingToTask;
    }

    public bool GetIdleStatus()
    {
        return isWorkerIdle;
    }
}
