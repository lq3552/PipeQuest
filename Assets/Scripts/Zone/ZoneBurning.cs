using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneBurning : ZoneManipulateParticle
{
    [SerializeField] ParticleSystem burningEffect;
    private float delay = 4.5f;

    protected override void HandleGasParticle(Collider other)
    {
        other.gameObject.GetComponent<GasParticle>().DestroyOnTimer(delay, BurnGas);
    }

    private void BurnGas(GameObject gasParticleObject)
    {
        gasParticleObject.SetActive(false);
        Instantiate<ParticleSystem>(burningEffect, transform.position, burningEffect.transform.rotation);
    }

    protected override void HandleGasParticleOutOfZone(Collider other)
    {
        other.gameObject.GetComponent<GasParticle>().StopDestroyOnTimer(BurnGas);
    }
}
