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
    [SerializeField] private List<Waypoint> waypoints;
    
    [SerializeField] private IdleWorkersRoomController idleWorkersRoomController;

    // public static event Action<int, float> OnTaskStarted = delegate { };

    // public static event Action<int, Transform> OnProgressBarAdded = delegate { };

    // public static event Action<int> OnProgressBarRemoved = delegate { };

    void Start()
    {
        // INIT TASK VARIABLE VALUES:
        taskName = task.taskName;
        numberOfWorkersToStart = task.numberOfWorkersToStart;
        timeOfCompletion = task.timeOfCompletion;
        isCompleted = task.isCompleted;
        isTaskBeingDone = task.isTaskBeingDone;



        // // SUBSCRIBE EVENTS:    
        // GameEventSystem.current.OnEnterTask += OnEnterTask;
        // GameEventSystem.current.OnExitTask += OnExitTask;

        // TRIGGER PROGRESS BAR EVENT:
        // OnProgressBarAdded(id, this.transform);
    }

    void OnMouseOver()
    {
        // Show UI with Task Informations
    }

    void OnMouseExit()
    {
        // Remove UI with Task Informations
    }

    void OnMouseDown()
    {
        if (waypoints.Count == 0)
        {
            Debug.Log($"There is no more room in task {taskName}");
            return;
        }
        
        bool haveIdleWorkers = idleWorkersRoomController.GetIdleWorkersList().Count > 0;
        
        if (haveIdleWorkers == false)
        {
            Debug.Log($"No idle workers! Please carry out more hires!");
            return;
        }

        WorkerController worker = idleWorkersRoomController.SelectOneWorkerFromList();
        int workerId = worker.id;

        Waypoint taskVacantWaypoint = waypoints[0];
        waypoints.Remove(waypoints[0]);
        
        GameEventSystem.current.WorkerSentToEnterTaskRoom(workerId, taskVacantWaypoint);
        
    }
}
