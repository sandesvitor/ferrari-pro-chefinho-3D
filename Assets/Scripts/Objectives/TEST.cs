using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class TEST : MonoBehaviour
{
    private TimerController timer;

    public float duration;

    void Start()
    {
        timer = GameObject.Find("TimerController").GetComponent<TimerController>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            timer.StartCountdown(duration);
        }
    }
}
