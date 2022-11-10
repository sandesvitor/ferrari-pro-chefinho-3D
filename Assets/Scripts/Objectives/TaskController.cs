using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    public Task task;

    public string taskName;
    public int numberOfWorkersToStart;
    public float timeOfCompletion;
    public bool isCompleted;
    public LevelObjectiveController levelObjectiveController;

    [SerializeField] private List<GameObject> workersInsideTaskList; 

    void Start()
    {
        taskName = task.taskName;
        numberOfWorkersToStart = task.numberOfWorkersToStart;
        timeOfCompletion = task.timeOfCompletion;
        isCompleted = task.isCompleted;

        levelObjectiveController = GameObject.Find("LevelObjectiveController").GetComponent<LevelObjectiveController>();
        levelObjectiveController.tasks.Add(this);
    }

    public void BindWorkerToTask(GameObject worker)
    {
        if (workersInsideTaskList.Count < numberOfWorkersToStart)
        {
            workersInsideTaskList.Add(worker);
        }
    }

    public void UnbindWorkerToTask(GameObject worker)
    {
        if (workersInsideTaskList.Count <= numberOfWorkersToStart)
        {
            workersInsideTaskList.Remove(worker);
        }
    }

    public bool DoesTaskMeetConditionsToStart(GameObject worker)
    {
        bool haveRighNumberOfWorkers = workersInsideTaskList.Count == numberOfWorkersToStart ? true : false;
        bool isWorkerInsideTask = workersInsideTaskList.Contains(worker);
        return haveRighNumberOfWorkers && isWorkerInsideTask;
    }

    public IEnumerator TaskTimer()
    {
        yield return new WaitForSeconds(timeOfCompletion);
        isCompleted = true;

    }

    void OnDrawGizmos()
    {
        if (isCompleted == false)
        {
            Gizmos.color = Color.gray;
            Gizmos.DrawSphere(this.transform.position, 4f);
        }
        else
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawSphere(this.transform.position, 4f);
        }
    }
}
