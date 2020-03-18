using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Grenade : MonoBehaviour
{
    [SerializeField] AudioClip throwSound;
    [SerializeField] AudioClip touchSound;
    [SerializeField] AudioClip explosionSound;
	[SerializeField] GameObject explosion;

    AudioSource audioSource;

    Animator animator;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(throwSound);
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        audioSource.PlayOneShot(touchSound);
        GetComponent<Rigidbody>().mass *= 100;
    }

    public void Explode()
    {
        GameObject explosionInstance = Instantiate(explosion, this.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(explosionSound, explosionInstance.transform.position);
        Destroy(explosionInstance, 1.5f);
        Destroy(this.gameObject);

        Collider[] coll = Physics.OverlapSphere(transform.position, 1.5f);

        for (int i = 0; i < coll.Length; i++)
        {
            if (coll[i].gameObject.GetComponent<ParasiteController>() != null)
            {
                coll[i].gameObject.GetComponent<ParasiteController>().PlayFallBackAnimation();
                coll[i].gameObject.GetComponent<ParasiteController>().health -= 20;
            }

        }
    }

}
