using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFunction : MonoBehaviour
{
    [SerializeField] private int zoneType;

    private int count = 0;

    // Properties
    public int ZoneType
    {
        get { return zoneType; }
    }


    // Add force to gas particles
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Gas"))
        {
            Rigidbody gasRigidbody = other.gameObject.GetComponent<Rigidbody>();
            switch (zoneType)
            {
                case 0:
                    gasRigidbody.AddForce(-transform.up * 5f, ForceMode.Force);
                    break;
                case 1:
                    gasRigidbody.AddForce(-transform.up * 2f, ForceMode.Force);
                    break;
                case 2:
                    break;
                case 3:
                    Debug.Log(count++);
                    Destroy(other.gameObject);
                    break;
                default:
                    break;

            }
        }
    }
}
