using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent && other.transform.parent.GetComponentInChildren<AmmoController>())
        {
            other.transform.parent.GetComponentInChildren<AmmoController>().PickUpAmmunition();
            Destroy(gameObject);    
        }
    }
}
