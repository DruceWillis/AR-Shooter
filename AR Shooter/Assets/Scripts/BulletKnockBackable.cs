using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKnockBackable : Bullet
{
    void Start()
    {
        damage = 20;        
    }

    protected override void OnCollisionEnter(Collision other)
    {
        if (other.transform.GetComponent<ParasiteController>() != null)
            other.transform.GetComponent<ParasiteController>().KnockBack();
        base.OnCollisionEnter(other);
    }

}
