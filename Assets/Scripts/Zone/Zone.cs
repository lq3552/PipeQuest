using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    protected abstract void HandleGasParticle(Collider other);
}
