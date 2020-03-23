using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.Experimental.XR;
using System;

public class Bullet : MonoBehaviour
{
    public virtual int damage {get; protected set;}
    protected Rigidbody rigidbody {get; set;}

    Vector3 hitPos;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
            return;
        damage = 10;
        Fly();
        Destroy(gameObject, 3f);
    }

    protected void Fly()
    {
        rigidbody.AddForce(Vector3.forward * 50, ForceMode.Impulse);
    }

    protected void OnCollisionEnter(Collision other)
    {
        var col = other.transform.GetComponent<ICatchable>();
        if (col == null)    return;
        other.transform.GetComponent<ICatchable>().Apply(this);
    }
}
