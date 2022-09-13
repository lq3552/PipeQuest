using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Zone : MonoBehaviour
{
    // modify status of the gas particle during its stay
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            HandleGasParticle(other);
        }
    }

    protected abstract void HandleGasParticle(Collider other);

}
