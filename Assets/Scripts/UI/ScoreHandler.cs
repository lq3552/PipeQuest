using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreHandler : MonoBehaviour
{
    private int score;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private List<ZoneReceiver> gasReceiverList;
    const string ScorePrefix = "Score: ";

    private void Awake()
    {
        score = 0;
        // Note: string is immutable in C#
        DisplayScore(this, 0);
        foreach (ZoneReceiver gasReceiver in gasReceiverList)
        {
            gasReceiver.OnGasReceived += AddPoints;
            gasReceiver.OnGasReceived += DisplayScore;
        }
    }

    private void DisplayScore(object sender, int placeHolder)
    {
        scoreText.text = ScorePrefix + score.ToString();
    }

    private void AddPoints(object sender, int point)
    {
        score += point;
    }
}
