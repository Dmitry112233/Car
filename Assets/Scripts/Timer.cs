using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public bool IsFifnished;

    private TextMeshProUGUI uiText;
    private int remainingDuration;

    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            yield return new WaitForSeconds(1f);
            uiText.text = $"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
            remainingDuration--;
        }

        IsFifnished = true;
    }

    public void RestartTimer(int duration)
    {
        IsFifnished = false;
        remainingDuration = duration;
        StartCoroutine(UpdateTimer());
    }

    public void IncreaseTime(int seconds)
    {
        remainingDuration += seconds;
    }
}
