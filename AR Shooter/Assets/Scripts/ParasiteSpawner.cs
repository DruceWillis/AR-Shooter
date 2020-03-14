using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePrefab;
    [SerializeField] GameObject showPlaneCP;

    public bool spawnedZombie = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distance = showPlaneCP.GetComponent<ShowPlaneCP>().distanceBetweenPlaneCenterAndPlayer;
        if (distance > 2f && !spawnedZombie)
        {
            GameObject zombieInstance = Instantiate(zombiePrefab, showPlaneCP.GetComponent<ShowPlaneCP>().planeCenter, Quaternion.identity);
            spawnedZombie = true;
        }

    }
}
