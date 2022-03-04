using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{

    public GameObject pickupeffect;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            pickup();
        }
    }

    void pickup()
    {
        Destroy(gameObject);
    }
}
