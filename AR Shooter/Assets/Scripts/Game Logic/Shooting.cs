﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;

public class Shooting : MonoBehaviour
{
    
	[SerializeField] GameObject gameCamera;
	[SerializeField] GameObject explosion;

	[SerializeField] GameObject barrel;
	[SerializeField] GameObject shellLauncher;

    [SerializeField] AudioClip shotSound;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject shell;
    [SerializeField] GameObject muzzleFlashPrefab;

    public void Shoot()
    {
        RaycastHit hit;

        if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit))
        {
            
                //Destroy(hit.transform.gameObject);
                var ammoController = this.GetComponent<BaseWeapon>();

                if (ammoController.currentAmmo == 0 && ammoController.additionalAmmo > 0)
                {
                    ammoController.HandleReload();
                    return;
                }
                else if (ammoController.currentAmmo == 0 && ammoController.additionalAmmo == 0)
                    return;
                
                if(this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Reload"))
                    return;

                ammoController.currentAmmo -= 1;
                this.GetComponent<Animator>().SetTrigger("ShotFired");

                GameObject go = Instantiate(explosion, hit.point, Quaternion.LookRotation(hit.normal));

                GameObject bulletInstance = Instantiate(bullet, barrel.transform.position, barrel.transform.rotation);
                AudioSource.PlayClipAtPoint(shotSound, bulletInstance.transform.position);
                GameObject shellInstance = Instantiate(shell, shellLauncher.transform.position, shellLauncher.transform.rotation);
                
                shellInstance.GetComponent<Rigidbody>().velocity = shellInstance.transform.TransformDirection(Vector3.left * 0.5f);
                // shellInstance.GetComponent<Rigidbody>().AddForce(Vector3.left, ForceMode.Impulse);

                var rotation = Camera.main.transform.rotation;
                rotation.y += .9f;

                GameObject muzzleFlashInstance = Instantiate(muzzleFlashPrefab, barrel.transform.position, rotation);

                Destroy(muzzleFlashInstance, 0.15f);
                Destroy(shellInstance, 5f);


                bulletInstance.GetComponent<Bullet>().ReceiveHitPosition(hit.point);
                if (hit.transform.GetComponent<ParasiteController>() != null)
                {
                    hit.transform.GetComponent<ParasiteController>().health -= 10;
                    hit.transform.GetComponent<ParasiteController>().PlayFallBackAnimation();
                    Destroy(bulletInstance);
                }
                else
                {
                    Destroy(bulletInstance, 1f);
                }
        }
    }
}
