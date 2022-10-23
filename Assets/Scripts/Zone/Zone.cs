using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// All types of zones
/// </summary>
public abstract class Zone : MonoBehaviour
{
    protected abstract void HandleGasParticle(Collider other);
}
