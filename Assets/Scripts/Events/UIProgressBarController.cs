using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBarController : MonoBehaviour
{
    [SerializeField] private Image progressBarPrefab;

    private Dictionary<int, Image> progressBars = new Dictionary<int, Image>();

    // private void Awake()
    // {
    //     TaskController.OnProgressBarAdded += AddProgressBar; 
    //     TaskController.OnProgressBarRemoved += RemoveProgressBar; 
    //     TaskController.OnTaskStarted += StartProgressBarCountdown;
    // }

    // private void AddProgressBar(int id, Transform taskTransform)
    // {
    //     Image progressBarInstance = Instantiate(progressBarPrefab, transform); 
    //     UIProgressBar progressBarScript = progressBarInstance.GetComponent<UIProgressBar>();

    //     progressBars.Add(id, progressBarInstance);
    //     progressBarScript.SetTaskProgress(taskTransform);
    // }

    // private void StartProgressBarCountdown(int id, float timeOfCompletion)
    // {
    //     UIProgressBar progressBarScript = progressBars[id].GetComponent<UIProgressBar>();        
    //     StartCoroutine(progressBarScript.TaskTimerProgressBar(timeOfCompletion));
    // }

    // private void RemoveProgressBar(int id)
    // {
    //     Destroy(progressBars[id].gameObject);
    //     // progressBars.Remove()
    // }
}
