using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseWeapon : MonoBehaviour
{

    [SerializeField] GameObject ammoText;


    public int currentAmmo = 30;
    public int additionalAmmo = 60;
    
    private const int MAX_CURRENT_AMMO = 30;
    private const int MAX_ADDITIONAL_AMMO = 90;

    private int tempAmmo;

    void Start()
    {
        
    }

    void Update()
    {
        ammoText.GetComponent<TextMeshProUGUI>().text = currentAmmo + "/" + additionalAmmo;
    }

    public void HandleReload()
    {
        if (currentAmmo == 30)
            return;

        this.GetComponent<Animator>().SetTrigger("Reload");
        AudioSource.PlayClipAtPoint(this.GetComponent<Reload>().reloadSound, this.transform.position);

        tempAmmo = MAX_CURRENT_AMMO - currentAmmo;
        tempAmmo = additionalAmmo >= tempAmmo ? tempAmmo : additionalAmmo;
        currentAmmo += tempAmmo;
        additionalAmmo -= tempAmmo;
    }

    public void PickUpAmmunition()
    {
        if (additionalAmmo < MAX_ADDITIONAL_AMMO - MAX_CURRENT_AMMO)
            additionalAmmo += 30;
        else
            additionalAmmo = 90;
    }
}
