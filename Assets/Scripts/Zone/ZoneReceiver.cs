using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneReceiver : ZoneManipulateParticle
{
    private int count = 0;

    // destroy and count gas particles received
    protected override void HandleGasParticle(Collider other)
    {
        other.gameObject.GetComponent<GasParticle>().DelayTillDestroy = 1.0f;
        count++;
        Debug.Log("Received:" + count);
    }
}
