using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonePressuredFunction : ZoneFunction
{
    // Exert force on gas; TODO: better-designed  virtual/abstract - override
    protected override void HandleGasParticle(GameObject gasObject, Rigidbody gasRigidbody)
    {
        gasRigidbody.AddForce(forward * 2.5f, ForceMode.Force);
    }
}
