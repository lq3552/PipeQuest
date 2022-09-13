using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePressured : ZoneAddForce
{
    protected override void Start()
    {
        base.Start();
        if (forceMagnitude <= 0f)
            forceMagnitude = 2.5f;
    }

    protected override void HandleGasParticle(Collider other)
    {
        Rigidbody gasRigidbody = other.gameObject.GetComponent<Rigidbody>();
        gasRigidbody.AddForce(forward * forceMagnitude, ForceMode.Force);
    }
}