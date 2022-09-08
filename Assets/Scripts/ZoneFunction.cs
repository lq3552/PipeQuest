using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneFunction : MonoBehaviour
{
    [SerializeField] private int zoneType;

    private int count = 0;
    private Vector3 forward;

    // Properties
    public int ZoneType
    {
        get { return zoneType; }
    }

    private void Start()
    {
        if(zoneType == 0)
        {
            forward = transform.parent.Find("Noozle").position;
        }
        else
        {
            forward = -transform.up;
        }
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
                    gasRigidbody.AddForce((forward - other.gameObject.transform.position).normalized * 5f, ForceMode.Force); // This code looks messy
                    break;
                case 1:
                    gasRigidbody.AddForce(forward * 2.5f, ForceMode.Force);
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
