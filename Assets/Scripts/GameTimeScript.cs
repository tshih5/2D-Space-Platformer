using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GameTimeScript : MonoBehaviour
{
    public Text timerText;
    [SerializeField] private float secondsCount;
    [SerializeField] private int minuteCount;
    [SerializeField] private int hourCount;



    void Update()
    {
        UpdateTimerUI();
    }

    public void UpdateTimerUI()
    {
        //set timer UI
        secondsCount += Time.deltaTime;
        timerText.text = hourCount + ":" + minuteCount.ToString("00") + ":" + ((int)secondsCount).ToString("00"); //h:mm:ss format
        if (secondsCount >= 60)
        {
            minuteCount++;
            secondsCount = 0;
        }
        else if (minuteCount >= 60)
        {
            hourCount++;
            minuteCount = 0;
        }
    }

    public int GetTimeInSeconds()
    {
        return (int)secondsCount + minuteCount * 60 + hourCount * 3600;
    }

    public string GetTimeText()
    {
        return timerText.text;
    }
}
