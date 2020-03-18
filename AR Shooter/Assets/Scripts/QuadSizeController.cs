using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadSizeController : MonoBehaviour
{

    void Start()
    {
        transform.localScale = new Vector3(Circle.radius * 3, Circle.radius * 3, 1);    
    }

}
