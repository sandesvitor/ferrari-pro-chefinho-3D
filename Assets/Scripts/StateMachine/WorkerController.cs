using UnityEngine;
using UnityEngine.AI;

public class WorkerController : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Camera cam;
    [SerializeField] private bool isWorkerFollowingMouse = true;
    [SerializeField] private bool isWorkerDoingTask = false;
    [SerializeField] private Vector2 speedRange = new Vector2(7f, 10f);

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();

        agent.speed = Random.Range(speedRange.x, speedRange.y);
    }

    void Update()
    {
        if(isWorkerFollowingMouse)
        {
            HandlePathFindingMovement();
        }
    }

    private void HandlePathFindingMovement()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                // MOVE OUR AGENT
                agent.SetDestination(hit.point);
            }
        }
    }

    public void OnMouseDown()
    {
        CameraController.instance.followTransform = this.transform;
    }

    public void FollowMouse()
    {
        isWorkerFollowingMouse = true;
    }

    public void StopFollowingMouse()
    {
        isWorkerFollowingMouse = false;
    }

    public bool GetFollowStatus()
    {
        return isWorkerFollowingMouse;
    }

    public bool GetTaskStatus()
    {
        return isWorkerDoingTask;
    }

    public void StartTask()
    {
        isWorkerDoingTask = true;
    }

    public void FinishTask()
    {
        isWorkerDoingTask = false;
    }
}
