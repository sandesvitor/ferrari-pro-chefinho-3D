using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Objective/Level Objective")]
public class LevelObjective : ScriptableObject
{
    public Task[] tasks;
    
    public void CheckTasksStartCondition(GameObject worker){

    }     
}
