using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDamageLogic : MonoBehaviour
{
    [SerializeField] GameObject player;
    Coroutine dmgPlayer;

    // bool isInside = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if(!isInside)
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealthController>())
        {
            // isInside = false;
            dmgPlayer = StartCoroutine(DamagePlayer(other, false));
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealthController>())
        {
            // isInside = true;
            if (dmgPlayer != null)
                StopCoroutine(dmgPlayer);
        }        
    }

    // private void OnCollisionStay(Collision other) {
    //     if (other.transform.GetComponent<PlayerHealthController>())
    //     {
    //         print("Player is inside");
    //     }
    // }

    // private void OnTriggerStay(Collider other)
    // {
    //     if (other.transform.GetComponent<PlayerHealthController>())
    //     {
    //         print("Player is inside");
    //     }
    //     else
    //         print("Player is outside");
    // }

    IEnumerator DamagePlayer(Collider player, bool isInside)
    {
        while (!isInside)
        {
            player.GetComponent<PlayerHealthController>().health -= 10;
            yield return new WaitForSeconds(1f);
        }
    }
}
