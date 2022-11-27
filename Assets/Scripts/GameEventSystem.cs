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
    
    // public event Action<int, Waypoint> OnWorkerSpawn;
    // public void WorkerSpawn(int id, Waypoint waypoint)
    // {
    //     if(OnWorkerSpawn != null)
    //     {
    //         OnWorkerSpawn(id, waypoint);
    //     }
    // }
    
    public event Action<int, Waypoint> OnWorkerSentToEnterTaskRoom;
    public void WorkerSentToEnterTaskRoom(int workerId, Waypoint waypoint)
    {
        if(OnWorkerSentToEnterTaskRoom != null)
        {
            OnWorkerSentToEnterTaskRoom(workerId, waypoint);
        }
    }
    
    // public event Action<int> OnWorkerStartToDoTask;
    // public void WorkerStartToDoTask(int id)
    // {
    //     if(OnWorkerStartToDoTask != null)
    //     {
    //         OnWorkerStartToDoTask(id);
    //     }
    // }
    
}
