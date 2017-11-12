using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InverterZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<EntityBehaviour>())
        {
            other.GetComponent<EntityBehaviour>().InvertMovement();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<EntityBehaviour>())
        {
            other.GetComponent<EntityBehaviour>().InvertMovement();
        }
    }
}
