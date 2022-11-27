using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleWorkersRoomController : MonoBehaviour
{
    [SerializeField] private List<WorkerController> workers;

    void Start()
    {
        GameObject[] workersGameObjects = GameObject.FindGameObjectsWithTag("WageSlave");
        for (int i = 0; i < workersGameObjects.Length; i++)
        {
            workers.Add(workersGameObjects[i].GetComponent<WorkerController>());
        }
    }

    public List<WorkerController> GetIdleWorkersList()
    {
        return workers;
    }

    public WorkerController SelectOneWorkerFromList()
    {
        WorkerController workerSelected = workers[0];
        workers.Remove(workerSelected);
        
        return workerSelected;
    }
}
