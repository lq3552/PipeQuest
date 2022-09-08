using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZoneFunction : MonoBehaviour
{
    protected Vector3 forward;

    private void Start()
    {
        SetForwardDirection();
    }

    // Add force to gas particles
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            Rigidbody gasRigidbody = other.gameObject.GetComponent<Rigidbody>();
            HandleGasParticle(other.gameObject, gasRigidbody);
        }
    }

    protected virtual void SetForwardDirection()
    {
        forward = -transform.up;
    }
    protected abstract void HandleGasParticle(GameObject gasObject, Rigidbody gasRigidbody);
}
