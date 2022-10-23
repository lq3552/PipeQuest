using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// define zones that manipulate the existence and effect of gas particles
/// </summary>
public abstract class ZoneManipulateParticle : Zone
{
    // modify status of the gas particle once it enters the zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            HandleGasParticle(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            HandleGasParticleOutOfZone(other);
        }
    }

    protected abstract void HandleGasParticleOutOfZone(Collider other);
}
