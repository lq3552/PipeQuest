using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBurning : ZoneManipulateParticle
{
    private float delay = 2.5f;

    protected override void HandleGasParticle(Collider other)
    {
        GasParticle gasScript = other.gameObject.GetComponent<GasParticle>();
        gasScript.DelayTillDestroy = delay;
        gasScript.IsInZone = true;
    }
}
