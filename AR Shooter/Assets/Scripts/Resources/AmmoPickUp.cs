using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent && other.transform.parent.GetComponentInChildren<BaseWeapon>() &&
                other.transform.parent.GetComponentInChildren<BaseWeapon>().additionalAmmo < 90)
        {
            other.transform.parent.GetComponentInChildren<BaseWeapon>().PickUpAmmunition();
            Destroy(gameObject);    
        }
    }
}
