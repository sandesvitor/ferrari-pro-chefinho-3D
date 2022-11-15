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

    void Start()
    {
        taskName = task.taskName;
        numberOfWorkersToStart = task.numberOfWorkersToStart;
        timeOfCompletion = task.timeOfCompletion;
        isCompleted = task.isCompleted;
        isTaskBeingDone = task.isTaskBeingDone;
        id = task.id;
    
        GameEventSystem.current.OnEnterTask += OnEnterTask;
    }

    private void OnEnterTask(int id)
    {
        if (id != this.id)
        {
            return;
        }
        
        if (workers.Count == numberOfWorkersToStart && isCompleted == false)
        {
            StartCoroutine(StartTaskLifecycle());
        }
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "WageSlave")
        {
            workers.Add(collider.gameObject.GetComponent<WorkerController>());
            GameEventSystem.current.EnterTask(id);
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "WageSlave")
        {
            workers.Remove(collider.gameObject.GetComponent<WorkerController>());
        }
    }

    public IEnumerator StartTaskLifecycle()
    {
        float remainingDuration = timeOfCompletion;
        isTaskBeingDone = true;
        //progressBarFill.enabled = true;

        for (int i = 0; i < workers.Count; i++)
        {
            workers[i].StartTask();
        }

        while(remainingDuration >= 0)
        {
            //progressBarFill.color = GetProgressBarColor(progressBarFill.fillAmount);
            Debug.Log($"Remaining Seconds: {remainingDuration.ToString()}");
            //progressBarFill.fillAmount = Mathf.InverseLerp(0, timeOfCompletion, remainingDuration);
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
