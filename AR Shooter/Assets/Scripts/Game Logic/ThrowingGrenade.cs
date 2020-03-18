using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ThrowingGrenade : MonoBehaviour
{
    [SerializeField] Transform grenadePos;
    [SerializeField] GameObject cooldownFiller;

	public GameObject grenadePrefab;
    [SerializeField] float cooldown;

    private float cooldownTimer = 0f;

    public void ThrowGrenade()
    {
        if (cooldownTimer > 0 || this.GetComponent<GrenadeController>().grenades < 1)
            return;
        
        GameObject grenadeInstance = Instantiate(grenadePrefab, grenadePos.position, grenadePos.rotation);
        grenadeInstance.GetComponent<Rigidbody>().AddForce(grenadePos.forward * 5f, ForceMode.Impulse);
        this.GetComponent<GrenadeController>().grenades--;

        cooldownTimer = cooldown;
    }

    void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
            cooldownFiller.GetComponent<Image>().fillAmount = cooldownTimer / cooldown;
        }
    }

}
