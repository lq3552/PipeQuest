using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasParticle : MonoBehaviour
{
    private bool isInZone = false;
    private float delayTillDestroy = 0f;

    [SerializeField] ParticleSystem burningEffect;

    public bool IsInZone
    {
        set
        {
            isInZone = value;
        }
        get
        {
            return isInZone;
        }
    }

    public float DelayTillDestroy
    {
        set
        {
            delayTillDestroy = value;
        }
        get
        {
            return delayTillDestroy;
        }
    }

    // TODO: for now just for the sake of using "events". Should found a better usage
    private void Update()
    {
        if (IsInZone)
        {
            if(delayTillDestroy <= 0)
            {
                EventManager.DestroyGasInZoneEvent += DestroyGas;
            }
            else
            {
                delayTillDestroy -= Time.deltaTime;
            }
        }
        else
        {
            EventManager.DestroyGasInZoneEvent -= DestroyGas;
        }

    }

   private void DestroyGas()
    {
        gameObject.SetActive(false);
    }
}
