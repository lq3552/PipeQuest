using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void DestroyGasInZone();
    public static event DestroyGasInZone DestroyGasInZoneEvent;

    private void Update()
    {
        ManipulateInZone();
    }

    private void ManipulateInZone()
    {
        if (DestroyGasInZoneEvent != null)
            DestroyGasInZoneEvent();
    }
}
