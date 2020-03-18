using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePackPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent && other.transform.parent.GetComponentInChildren<GrenadeController>() &&
                other.transform.parent.GetComponentInChildren<GrenadeController>().grenades < 5)
        {
            other.transform.parent.GetComponentInChildren<GrenadeController>().PickUpGrenades();
            Destroy(gameObject);    
        }
    }
}
