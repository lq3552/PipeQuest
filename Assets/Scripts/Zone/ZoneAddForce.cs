using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneAddForce : Zone
{
    protected Vector3 forward;
    protected float forceMagnitude;

    protected virtual void Start()
    {
        SetForwardDirection();
    }

    protected virtual void SetForwardDirection()
    {
        forward = -transform.up;
    }

    protected override void HandleGasParticle(Collider other)
    {
        Rigidbody gasRigidbody = other.gameObject.GetComponent<Rigidbody>();
        gasRigidbody.AddForce(forward * forceMagnitude, ForceMode.Force);
    }
}
