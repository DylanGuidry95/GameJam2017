using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InverterZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EntityMovement>())
        {
            other.GetComponent<EntityMovement>().InvertMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EntityMovement>())
        {
            other.GetComponent<EntityMovement>().InvertMovement();
        }
    }
}
