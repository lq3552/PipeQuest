using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasParticle : MonoBehaviour
{
    public delegate void ActionOnTimer(GameObject gasObject);
    private float timer = 0f;
    private ActionOnTimer actionOnTimer;

    public void DestroyOnTimer(float timer, ActionOnTimer actionOnTimer)
    {
        this.timer = timer;
        this.actionOnTimer += actionOnTimer;
    }

    public void StopDestroyOnTimer(ActionOnTimer actionOnTimer)
    {
        this.actionOnTimer -= actionOnTimer;
    }

    private void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (IsTimerComplete())
        {
            actionOnTimer?.Invoke(gameObject);
        }
    }

    private bool IsTimerComplete()
    {
        return timer <= 0f;
    }
}
