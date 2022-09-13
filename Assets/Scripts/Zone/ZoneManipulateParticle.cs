using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZoneManipulateParticle : Zone
{
    // modify status of the gas particle once it enters the zone

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            other.gameObject.GetComponent<GasParticle>().IsInZone = true;
            HandleGasParticle(other);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            other.gameObject.GetComponent<GasParticle>().IsInZone = false;
        }
    }
}
