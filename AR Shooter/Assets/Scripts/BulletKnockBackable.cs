using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKnockBackable : Bullet
{
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
            return;
        damage = 20;
        Fly();      
        Destroy(gameObject, 3f);
    }

    public void KnockBack(GameObject enemy)
    {
        enemy.transform.Translate(Vector3.back);
    }
}
