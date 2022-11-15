using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class WorkerTaskInterface : MonoBehaviour
{
    public LevelObjectiveController levelObjectiveController;

    [SerializeField] private WorkerController workerSelf;
    [SerializeField] private List<TaskController> taskControllerList; 

    void Start()
    {
        workerSelf = this.gameObject.GetComponentInParent<WorkerController>();
        levelObjectiveController = GameObject.Find("LevelObjectiveController").GetComponent<LevelObjectiveController>();
    }
    
    void Update()
    {
        CheckTasksStartCondition();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Task")
        {
            TaskController taskController = collider.gameObject.GetComponent<TaskController>();
            taskControllerList.Add(taskController);
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Task")
        {
            TaskController taskController = collider.gameObject.GetComponent<TaskController>();
            taskControllerList.Remove(taskController);
        }
    }

    private void CheckTasksStartCondition()
    {
        if (taskControllerList.Count <= 0)
        {
            return;
        }
        
        bool isTaskReady = levelObjectiveController.CheckTasksStartCondition(taskControllerList[0], workerSelf.gameObject);
        
        if (isTaskReady)
        {
            workerSelf.StartTask();
        }
        else 
        {
            workerSelf.FinishTask();
        }
    }
}
