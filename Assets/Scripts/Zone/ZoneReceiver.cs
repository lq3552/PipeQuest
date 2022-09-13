using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneReceiver : Zone
{
    int count;

    // destroy and count gas particles received
    protected override void HandleGasParticle(Collider other)
    {
        Debug.Log(++count);
        Destroy(other.gameObject);
    }
}
