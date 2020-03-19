using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using System;

public class Bullet : MonoBehaviour
{
    protected int damage = 10;
    protected float force = 40f;

    Vector3 hitPos;

    void Update()
    {
        if (hitPos == null)
            return;
        Fly();
    }

    public void ReceiveHitPosition(Vector3 hitPosition)
    {
        hitPos = hitPosition;
    }

    void Fly()
    {
        transform.position = Vector3.MoveTowards(transform.position, hitPos, force * Time.deltaTime); 
    }

    protected virtual void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<ParasiteController>() != null)
        {
            other.transform.GetComponent<ParasiteController>().health -= damage;
            other.transform.GetComponent<ParasiteController>().PlayFallBackAnimation();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 1f);
        }
    }
}
