using System;
using System.Collections.Generic;
using UnityEngine;

public class GameEventSystem : MonoBehaviour
{
    public static GameEventSystem current;

    private void Awake()
    {
        current = this;
    }
    
    public event Action<int, WorkerController> OnEnterTask;
    public void EnterTask(int id, WorkerController worker)
    {
        if(OnEnterTask != null)
        {
            OnEnterTask(id, worker);
        }
    }
    
    public event Action<int, WorkerController> OnExitTask;
    public void ExitTask(int id, WorkerController worker)
    {
        if(OnExitTask != null)
        {
            OnExitTask(id, worker);
        }
    }
}
