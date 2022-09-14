using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZoneAddForce : Zone
{
    [SerializeField] protected float forceMagnitude = 0f;
    protected Vector3 forward;

    // modify status of the gas particle during its stay
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            HandleGasParticle(other);
        }
    }

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
