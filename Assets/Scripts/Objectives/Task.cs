using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Objective/Task")]
public class Task : ScriptableObject
{
    public string taskName;
    public int numberOfWorkersToStart;
    public float timeOfCompletion;
    public int id;
    
    public bool isCompleted = false;
    public bool isTaskBeingDone = false;
}
