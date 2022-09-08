using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneReceiverFunction : ZoneFunction
{
    int count;

    // destroy and count gas particles received
    protected override void HandleGasParticle(GameObject gasObject, Rigidbody gasRigidbody)
    {
        Debug.Log(++count);
        Destroy(gasObject);
    }
}
