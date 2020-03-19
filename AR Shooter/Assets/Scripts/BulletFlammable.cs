using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletFlammable : Bullet
{

    void Start()
    {
        damage = 15;
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<ParasiteController>() != null)
            other.transform.GetComponent<ParasiteController>().SetOnFire();
        base.OnCollisionEnter(other);
    }
}
