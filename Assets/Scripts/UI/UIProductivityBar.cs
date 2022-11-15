using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIProductivityBar : MonoBehaviour
{

    public Image productivityBar;
    public float secondsToEndProductivity;
    public float remainingDuration;

    void Start()
    {
        StartCoroutine(StartProductivityLoss());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            Debug.Log("SPACE");
            GainProductivity(1f);
        }
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

    private void GainProductivity(float boost)
    {
        float maxProductivity = remainingDuration + boost;
        if (maxProductivity >= secondsToEndProductivity)
        {
            remainingDuration = secondsToEndProductivity;
        }

        remainingDuration += boost;
    }

    private IEnumerator StartProductivityLoss()
    {
        remainingDuration = secondsToEndProductivity;

        while(remainingDuration >= 0)
        {
            Debug.Log($"{productivityBar.fillAmount}");
            productivityBar.color = GetProgressBarColor(productivityBar.fillAmount);
            productivityBar.fillAmount = Mathf.InverseLerp(0, secondsToEndProductivity, remainingDuration);
            remainingDuration -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
