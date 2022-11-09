using UnityEngine;
using UnityEngine.AI;

public class WorkerController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;

    void Update()
    {
        HandlePathFindingMovement();
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
}
