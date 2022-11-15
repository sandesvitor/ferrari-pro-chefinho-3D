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
    
    public event Action<int> OnEnterTask;
    public void EnterTask(int id)
    {
        if(OnEnterTask != null)
        {
            OnEnterTask(id);
        }
    }
}
