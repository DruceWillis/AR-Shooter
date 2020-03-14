using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using System;

public class Bullet : MonoBehaviour
{
    public float force = 2f;

    private Vector3 hitPos;

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

    private void Fly()
    {
        transform.position = Vector3.MoveTowards(transform.position, hitPos, force * Time.deltaTime); 
    }
}
