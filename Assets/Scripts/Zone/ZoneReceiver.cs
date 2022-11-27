using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneReceiver : ZoneManipulateParticle
{
    public event EventHandler<int> OnGasReceived;

    // destroy and count gas particles received
    protected override void HandleGasParticle(Collider other)
    {
        other.gameObject.GetComponent<GasParticle>().DestroyOnTimer(0.3f, ReceiveGas);
        OnGasReceived?.Invoke(this, 1);
    }

    private void ReceiveGas(GameObject gasParticleObject)
    {
        gasParticleObject.SetActive(false);
    }

    protected override void HandleGasParticleOutOfZone(Collider other)
    {
        other.gameObject.GetComponent<GasParticle>().StopDestroyOnTimer(ReceiveGas);
    }
}
