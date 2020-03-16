using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmunitionAndAidKitSpawner : MonoBehaviour
{

    [SerializeField] GameObject firstAidKit;
    [SerializeField] GameObject ammoBox;
    // [SerializeField] GameObject grenade;

    List<Vector3> randomPositions = new List<Vector3>();

    int count = 0;
    private float R = 20;
    private float r;
    private float theta;
    private float x;
    private float z;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnFirstAidKit");
        StartCoroutine("SpawnAmmoBox");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector3 RandomizeLocation()
    {
        Vector3 newPos;

        r = R * Mathf.Sqrt(Random.value);
        theta = Random.value * 2 * Mathf.PI;

        x = r * Mathf.Cos(theta);
        z = r * Mathf.Sin(theta);

        newPos = new Vector3(x, 0.5f, z);
        return newPos;
    }


    IEnumerator SpawnFirstAidKit()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);

            GameObject firstAidKitInstance = Instantiate(firstAidKit, RandomizeLocation(), Quaternion.identity);
            Destroy (firstAidKitInstance, 15f);
        }
    }
    
    IEnumerator SpawnAmmoBox()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            GameObject ammoBoxInstance = Instantiate(ammoBox, RandomizeLocation(), Quaternion.identity);
            Destroy(ammoBoxInstance, 15f);
        }

    }

    // IEnumerator SpawnGrenade()
    // {
    //     yield return new WaitForSeconds(5f);

    //     GameObject grenadeInstance = Instantiate(grenade, RandomizeLocation(), Quaternion.identity);
        
    // }

}
