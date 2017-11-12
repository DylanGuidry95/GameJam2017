using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EntityBehaviour>())
            other.GetComponent<EntityBehaviour>().TakeDamage(
                other.GetComponent<EntityBehaviour>().mHealth);
    }
}
