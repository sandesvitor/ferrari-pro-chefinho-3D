using UnityEngine;

[CreateAssetMenu (menuName = "Objective/Level Objective")]
public class LevelObjective : ScriptableObject
{
    public Task[] tasks;
    
    public void PrintTasksNames()
    {
        for (int i = 0; i < tasks.Length; i++)
        {
            Debug.Log($"Task {i + 1}: {tasks[i].taskName}");
        }
    }     
}