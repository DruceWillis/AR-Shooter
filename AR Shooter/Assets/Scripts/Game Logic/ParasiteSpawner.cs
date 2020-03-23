using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteSpawner : MonoBehaviour
{
    [SerializeField] GameObject parasitePrefab;
    [SerializeField] GameObject showPlaneCP;
    [SerializeField] GameObject player;

    public int maxParasites = 3;

    private static List<GameObject> parasites = new List<GameObject>();

    private int count = 0;
    private float R;
    private float r;
    private float theta;
    private float x;
    private float z;

    void Start()
    {
        R = Circle.radius;
        
        for (int i = 0; i < maxParasites; i++)
        {
            SpawnNewParasite();
        }   
    }

    void Update()
    {
        if (parasites.Count < maxParasites)
            SpawnNewParasite();
    }

    void SpawnNewParasite()
    {
        var newPos = RandomizeLocation();
        GameObject parasiteInstance = Instantiate(parasitePrefab, newPos, Quaternion.identity);
        parasiteInstance.GetComponent<ParasiteController>().target = player;
        parasites.Add(parasiteInstance);
        count++;
        parasiteInstance.name = "Parasite " + count;
    }

    private Vector3 RandomizeLocation()
    {
        r = R * Mathf.Sqrt(Random.value);
        theta = Random.value * 2 * Mathf.PI;

        x = r * Mathf.Cos(theta);
        z = r * Mathf.Sin(theta);

        var newPos = new Vector3(x, -0.6f, z);
        return newPos;
    }

    public static void RemoveParasiteFromList(GameObject parasite)
    {
        parasites.Remove(parasite);
    }
}
