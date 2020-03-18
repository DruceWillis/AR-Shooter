﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteSpawner : MonoBehaviour
{
    [SerializeField] GameObject parasitePrefab;
    [SerializeField] GameObject showPlaneCP;
    [SerializeField] GameObject player;

    public bool spawnedZombie = false;

    List<Vector3> randomPositions = new List<Vector3>();
    private static List<GameObject> parasites = new List<GameObject>();

    Vector3 newPos;
    int count = 0;
    private float R;
    private float r;
    private float theta;
    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        R = Circle.radius;
        
        for (int i = 0; i < 3; i++)
        {
            SpawnNewParasite();
        }   
    }

    // Update is called once per frame
    void Update()
    {
        if (parasites.Count < 3)
            SpawnNewParasite();
    }

    void SpawnNewParasite()
    {
        var newPos = RandomizeLocation();
        GameObject parasiteInstance = Instantiate(parasitePrefab, newPos, Quaternion.identity);
        parasiteInstance.GetComponent<ParasiteController>().player = player;
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

        newPos = new Vector3(x, -0.6f, z);
        randomPositions.Add(newPos);
        return newPos;
    }

    public static void RemoveParasiteFromList(GameObject parasite)
    {
        parasites.Remove(parasite);
    }
}
