using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePumpFunction : ZoneFunction
{

    protected override void SetForwardDirection()
    {
        forward = transform.parent.Find("Noozle").position;
    }

    // Exert force on gas towards noozle
    protected override void HandleGasParticle(GameObject gasObject, Rigidbody gasRigidbody)
    {
        gasRigidbody.AddForce((forward - gasObject.transform.position).normalized * 5f, ForceMode.Force);
    }
}
