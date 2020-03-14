﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reload : MonoBehaviour
{
    public AudioClip reloadSound;

    public void ReloadGun()
    {
        var currAmmo = this.GetComponent<AmmoController>().currentAmmo;
        var addAmmo = this.GetComponent<AmmoController>().additionalAmmo;

        if ((currAmmo == 0 && addAmmo == 0) || currAmmo == 30 || addAmmo == 0)
            return;
        this.GetComponent<Animator>().SetTrigger("Reload");
        this.GetComponent<AmmoController>().HandleReload();
        AudioSource.PlayClipAtPoint(reloadSound, this.transform.position);
    }

}