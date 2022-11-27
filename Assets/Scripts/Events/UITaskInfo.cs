using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITaskInfo : MonoBehaviour
{
    public Image prefabUI;
    private Image uiUse;

    void Start()
    {
        uiUse = Instantiate(prefabUI, GameObject.Find("Canvas_Task_Info").transform).GetComponent<Image>();    
    }

    void Update()
    {
        uiUse.transform.position = Camera.main.WorldToScreenPoint(transform.position);
    }
}
