using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProgressBar : MonoBehaviour
{
    [SerializeField] private float positionOffset;
    
    private Image progressBarFill;
    private Transform taskTransform;

    private void Awake()
    {
        progressBarFill = GetComponent<Image>();
    }

    private void Start()
    {
        progressBarFill.enabled = false;
    }

    public void SetTaskProgress(Transform taskTransform)
    {
        progressBarFill.enabled = true;
        this.taskTransform = taskTransform;
        this.transform.position = taskTransform.position + new Vector3(0, taskTransform.transform.localScale.y, 0f) * positionOffset;
        this.transform.rotation = taskTransform.rotation;
    }

    private Color GetProgressBarColor(float fillAmount)
    {
        if(fillAmount < 0.5f && fillAmount >= 0.25f)
        {
            return Color.yellow;
        }
        if(fillAmount < 0.25f)
        {
            return Color.red;
        }

        return Color.green;
    }

    public IEnumerator TaskTimerProgressBar(float timeOfCompletion)
    {
        float remainingDuration = timeOfCompletion;
        progressBarFill.enabled = true;

        while(remainingDuration >= 0)
        {
            progressBarFill.color = GetProgressBarColor(progressBarFill.fillAmount);
            progressBarFill.fillAmount = Mathf.InverseLerp(0, timeOfCompletion, remainingDuration);
            remainingDuration = remainingDuration - 1f;
            yield return new WaitForSeconds(1f);
        }
    }
}
