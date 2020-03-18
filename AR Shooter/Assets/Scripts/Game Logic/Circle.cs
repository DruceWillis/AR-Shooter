using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Circle : MonoBehaviour
{
    [Range(0, 50)]
    public int segments = 50;
    [Range(0, 50)]
    public float radiusOfCircle = 15;

    public static float radius;
    LineRenderer line;

    [SerializeField] GameObject zoneCollider;

    private void Awake()
    {
        radius = radiusOfCircle;
    }

    void Start()
    {
        line = gameObject.GetComponent<LineRenderer>();
        zoneCollider.GetComponent<SphereCollider>().radius = radius;
        
        line.enabled = true;
        line.positionCount = (segments + 1);
        line.useWorldSpace = false;
        CreatePointsAndDrawCircle();
    }

    void CreatePointsAndDrawCircle()
    {
        float x;
        float y;

        float angle = 20f;

        for (int i = 0; i < (segments + 1); i++)
        {
            x = Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
            y = Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

            line.SetPosition(i,new Vector3(x,y,0) );

            angle += (360f / segments);
        }
    }
}