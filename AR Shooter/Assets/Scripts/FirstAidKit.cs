using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerHealthController>())
        {
            other.gameObject.GetComponent<PlayerHealthController>().PickUpFirstAidKit();
            Destroy(gameObject);    
        }
    }
}
