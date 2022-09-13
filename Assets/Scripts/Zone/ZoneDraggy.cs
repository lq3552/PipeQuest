using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDraggy : ZoneAddForce
{
    protected override void Start()
    {
        base.Start();
        if (forceMagnitude >= 0f)
            forceMagnitude = -0.001f;
    }

    protected override void HandleGasParticle(Collider other)
    {
        Rigidbody gasRigidbody = other.gameObject.GetComponent<Rigidbody>();
        gasRigidbody.AddForce(gasRigidbody.velocity * forceMagnitude, ForceMode.Force);
    }
}