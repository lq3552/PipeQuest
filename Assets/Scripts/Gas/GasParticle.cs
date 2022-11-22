using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// provide behavior of gas particles
/// </summary>
public class GasParticle : MonoBehaviour
{
    // declare delegate that manipulate gas particles
    public delegate void ActionOnTimer(GameObject gasObject);

    // define timer variables 
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

        if (IsTimerComplete)
        {
            actionOnTimer?.Invoke(gameObject);
        }

        if (IsOutOfBoundary)
        {
            Destroy(gameObject);
        }
    }

    private bool IsOutOfBoundary => transform.position.x > GameConfigs.GameBoundRight
                                    || transform.position.x < GameConfigs.GameBoundLeft
                                    || transform.position.y > GameConfigs.GameBoundTop
                                    || transform.position.y < GameConfigs.GameBoundBottom;

    private bool IsTimerComplete => timer < 0f;
}
