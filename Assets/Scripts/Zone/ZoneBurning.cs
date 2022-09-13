using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBurning : ZoneManipulateParticle
{
    private float delay = 2.5f;

    protected override void HandleGasParticle(Collider other)
    {
        other.gameObject.GetComponent<GasParticle>().DelayTillDestroy = delay;
    }
}
