using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskInterface : MonoBehaviour
{
    [SerializeField] private TaskController taskController;

    void Start()
    {
        taskController = this.gameObject.GetComponentInParent<TaskController>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "WageSlave")
        {
            Debug.Log("Entre Task");
            taskController.BindWorkerToTask(collider.gameObject);
        }
        
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "WageSlave")
        {
            Debug.Log("Leave Task");
            taskController.UnbindWorkerToTask(collider.gameObject);
        }
    }
}
