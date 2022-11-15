using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TaskController : MonoBehaviour
{
    public Task task;

    public string taskName;
    public int numberOfWorkersToStart;
    public float timeOfCompletion;
    public bool isCompleted;
    public bool isTaskBeingDone;
    public LevelObjectiveController levelObjectiveController;

    [SerializeField] private Image progressBarFill;
    
    [SerializeField] private List<GameObject> workersInsideTaskList; 

    void Start()
    {
        taskName = task.taskName;
        numberOfWorkersToStart = task.numberOfWorkersToStart;
        timeOfCompletion = task.timeOfCompletion;
        isCompleted = task.isCompleted;
        isTaskBeingDone = task.isTaskBeingDone;

        levelObjectiveController = GameObject.Find("LevelObjectiveController").GetComponent<LevelObjectiveController>();
        levelObjectiveController.tasks.Add(this);
    
        progressBarFill.enabled = false;
    }

    void Update()
    {
        bool startTimer = levelObjectiveController.CheckIfWorkerIsDoingTask();

        if (startTimer == true && isTaskBeingDone == false)
        {
            StartCoroutine(TaskTimer());    
        }
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

    private Color GetProgressBarColor(float fillAmount)
    {
        if(fillAmount < 0.5f && fillAmount >= 0.25f)
        {
            return Color.yellow;
        }
        if(fillAmount < 0.25f)
        {
            return Color.red;
        }

        return Color.green;
    }

    public IEnumerator TaskTimer()
    {
        float remainingDuration = timeOfCompletion;
        isTaskBeingDone = true;
        progressBarFill.enabled = true;

        while(remainingDuration >= 0)
        {
            progressBarFill.color = GetProgressBarColor(progressBarFill.fillAmount);
            Debug.Log($"Remaining Seconds: {remainingDuration.ToString()} / FillAmount: {progressBarFill.fillAmount.ToString()}");
            progressBarFill.fillAmount = Mathf.InverseLerp(0, timeOfCompletion, remainingDuration);
            remainingDuration = remainingDuration - 1f;
            yield return new WaitForSeconds(1f);
        }

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
