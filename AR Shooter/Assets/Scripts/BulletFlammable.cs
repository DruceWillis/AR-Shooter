using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BulletFlammable : Bullet
{

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        if (rigidbody == null)
            return;
        damage = 15;
        Fly();
        Destroy(gameObject, 3f);
    }

    public void SetOnFire(GameObject fireEffect)
    {
        fireEffect.SetActive(true);
    }
}
