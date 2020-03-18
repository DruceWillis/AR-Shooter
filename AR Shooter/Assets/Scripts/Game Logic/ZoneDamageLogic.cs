using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneDamageLogic : MonoBehaviour
{
    [SerializeField] GameObject player;
    Coroutine dmgPlayer;

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerHealthController>())
        {
            dmgPlayer = StartCoroutine(DamagePlayer(other, false));
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealthController>())
        {
            if (dmgPlayer != null)
                StopCoroutine(dmgPlayer);
        }        
    }

    IEnumerator DamagePlayer(Collider player, bool isInside)
    {
        while (!isInside)
        {
            player.GetComponent<PlayerHealthController>().health -= 10;
            yield return new WaitForSeconds(1f);
        }
    }
}
