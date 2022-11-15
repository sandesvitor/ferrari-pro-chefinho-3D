using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public Task task;
    public int id;

    public string taskName;
    public int numberOfWorkersToStart;
    public float timeOfCompletion;
    public bool isCompleted;
    public bool isTaskBeingDone;

    [SerializeField] private List<WorkerController> workers;

    public static event Action<int, float> OnTaskStarted = delegate { };

    public static event Action<int, Transform> OnProgressBarAdded = delegate { };


    private void OnEnable()
    {
        OnProgressBarAdded(id, this.transform);
        // OnTaskStarted(id, timeOfCompletion);
    }

    void Start()
    {
        // INIT TASK VARIABLE VALUES:
        taskName = task.taskName;
        numberOfWorkersToStart = task.numberOfWorkersToStart;
        timeOfCompletion = task.timeOfCompletion;
        isCompleted = task.isCompleted;
        isTaskBeingDone = task.isTaskBeingDone;

        // SUBSCRIBE EVENTS:    
        GameEventSystem.current.OnEnterTask += OnEnterTask;
        GameEventSystem.current.OnExitTask += OnExitTask;
    }

    private void OnEnterTask(int id, WorkerController worker)
    {

        if (id == this.id)
        {
            workers.Add(worker);

            if (workers.Count == numberOfWorkersToStart && isCompleted == false)
            {
                TaskController.OnTaskStarted(id, timeOfCompletion);
                StartCoroutine(StartTaskLifecycle());
            }
        }
    }
    
    private void OnExitTask(int id, WorkerController worker)
    {
        if (id == this.id)
        {
            workers.Remove(worker);
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "WageSlave")
        {  
            WorkerController worker = collider.gameObject.GetComponent<WorkerController>();
            GameEventSystem.current.EnterTask(id, worker);
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "WageSlave")
        {
            WorkerController worker = collider.gameObject.GetComponent<WorkerController>();
            GameEventSystem.current.ExitTask(id, worker);
        }
    }

    public IEnumerator StartTaskLifecycle()
    {
        float remainingDuration = timeOfCompletion;
        isTaskBeingDone = true;

        for (int i = 0; i < workers.Count; i++)
        {
            workers[i].StartTask();
        }

        while(remainingDuration >= 0)
        {
            remainingDuration = remainingDuration - 1f;
            yield return new WaitForSeconds(1f);
        }

        for (int i = 0; i < workers.Count; i++)
        {
            workers[i].FinishTask();
        }

        isTaskBeingDone = false;
        isCompleted = true;
    }

    private void OnDrawGizmos()
    {
        if (isCompleted == false)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(this.transform.position, 4f);
        }
        
        if (isTaskBeingDone == true)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(this.transform.position, 4f);
        }

        if (isCompleted == true && isTaskBeingDone == false)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(this.transform.position, 4f);
        }
    }
}
