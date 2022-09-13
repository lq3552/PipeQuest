using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePump : ZoneAddForce
{
    protected override void Start()
    {
        base.Start();
        if (forceMagnitude <= 0f)
            forceMagnitude = 5.0f;
    }

    protected override void SetForwardDirection()
    {
        forward = transform.parent.Find("Noozle").position;
    }

    // Exert force on gas towards noozle
    protected override void HandleGasParticle(Collider other)
    {
        Rigidbody gasRigidbody = other.gameObject.GetComponent<Rigidbody>();
        gasRigidbody.AddForce((forward - other.gameObject.transform.position).normalized * forceMagnitude, ForceMode.Force);
    }
}
