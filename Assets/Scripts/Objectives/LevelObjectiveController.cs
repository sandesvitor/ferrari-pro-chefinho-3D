using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class LevelObjectiveController : MonoBehaviour
{    
    public LevelObjective levelObjective;
    public List<TaskController> tasks;

    [SerializeField] private bool startTimer; 

    public bool CheckTasksStartCondition(TaskController task, GameObject worker)
    {
        TaskController taskForValidation = tasks.Find(x => x == task);
        
        if(taskForValidation == null)
        {
            Debug.Log($"taskController is null!");
            return false;
        }

        bool doesTaskMeetConditionsToStart = taskForValidation.DoesTaskMeetConditionsToStart(worker);
        bool isTaskCompleted = taskForValidation.isCompleted;

        if (isTaskCompleted)
        {
            startTimer = false;
            return false;
        }

        if (!doesTaskMeetConditionsToStart)
        {
            return false;
        }

        startTimer = true;
        
        return true;
    }

    public bool CheckIfWorkerIsDoingTask()
    {
        return startTimer;
    }
}
