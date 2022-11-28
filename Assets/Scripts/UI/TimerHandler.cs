using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerHandler : MonoBehaviour
{
    private int time;
    [SerializeField] private TMP_Text timerText;
    const string timerPrefix = "Time: ";

    private void Awake()
    {
        time = 0;
    }

    private void Update()
    {
        DisplayTimer();
    }

    private void DisplayTimer()
    {
        timerText.text = timerPrefix + Mathf.FloorToInt(Time.time);
    }
}
