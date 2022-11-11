using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    private float remainingDuration;
    
    public Image progressBarFill;

    void Update()
    {
        if(progressBarFill.fillAmount >= 0.5f)
        {
            progressBarFill.color = Color.green;
        }
        if(progressBarFill.fillAmount < 0.5f && progressBarFill.fillAmount >= 0.25f)
        {
            progressBarFill.color = Color.yellow;
        }
        if(progressBarFill.fillAmount < 0.25f)
        {
            progressBarFill.color = Color.red;
        }
    }

    public void StartCountdown(float duration)
    {
        remainingDuration = duration;
        StartCoroutine(UpdateTimer(duration));
    }

    private IEnumerator UpdateTimer(float duration)
    {
        while(remainingDuration >= 0)
        {
            Debug.Log($"Remaining Seconds: {remainingDuration.ToString()}");
            progressBarFill.fillAmount = Mathf.InverseLerp(0, duration, remainingDuration);
            remainingDuration = remainingDuration - 0.01f;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
