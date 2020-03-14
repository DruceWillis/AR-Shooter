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
    AnimationClip clip;
    AnimationEvent animationEvent = new AnimationEvent();

    bool exploded = false;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.PlayOneShot(throwSound);
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // if (exploded)
        //     return;
        audioSource.PlayOneShot(touchSound);
        GetComponent<Rigidbody>().mass *= 100;
        // animationEvent.time = 1.5f;
        // animationEvent.functionName = "Explode";
        // clip = animator.runtimeAnimatorController.animationClips[0];
        // clip.AddEvent(animationEvent);
        // exploded = !exploded;
        
        // print(clip.length);
        // StartCoroutine(Explode());
    }

    public void PrintSmth()
    {
        print("bla");
    }

    public void Explode()
    {
        // yield return new WaitForSeconds(1.5f);

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
