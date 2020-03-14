using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteSpawner : MonoBehaviour
{
    [SerializeField] GameObject parasitePrefab;
    [SerializeField] GameObject showPlaneCP;

    public bool spawnedZombie = false;

    List<Vector3> randomPositions = new List<Vector3>();
    private static List<GameObject> parasites = new List<GameObject>();

    Vector3 newPos;
    int count = 0;
    float R = 20;
    float r;
    float theta;
    float x;
    float z;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnNewParasite();
        }
        // print(newPos);
        // print(Vector3.Distance(new Vector3(0, -0.6f, 0), newPos));
        
    }

    // Update is called once per frame
    void Update()
    {
        if (parasites.Count < 3)
            SpawnNewParasite();
        // float distance = showPlaneCP.GetComponent<ShowPlaneCP>().distanceBetweenPlaneCenterAndPlayer;
        // if (distance > 2f && !spawnedZombie)
        // {
        //     GameObject parasiteInstance = Instantiate(parasitePrefab, showPlaneCP.GetComponent<ShowPlaneCP>().planeCenter, Quaternion.identity);
        //     count++;
        //     parasiteInstance.name = "Parasite " + count;
        //     spawnedZombie = true;
        // }

    }

    void SpawnNewParasite()
    {
        r = R * Mathf.Sqrt(Random.value);
            theta = Random.value * 2 * Mathf.PI;

            x = r * Mathf.Cos(theta);
            z = r * Mathf.Sin(theta);

            newPos = new Vector3(x, -0.6f, z);
            randomPositions.Add(newPos);
            GameObject parasiteInstance = Instantiate(parasitePrefab, newPos, Quaternion.identity);
            parasites.Add(parasiteInstance);
            count++;
            parasiteInstance.name = "Parasite " + count;
    }

    public static void RemoveParasiteFromList(GameObject parasite)
    {
        parasites.Remove(parasite);
    }
}
