using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealthController : MonoBehaviour
{
    public int health = 100;

    [SerializeField] GameObject text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.GetComponent<TextMeshProUGUI>().text = "Health: " + health;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        // print(other.gameObject.GetComponent<ZombieController>().attacking);
        if (other.gameObject.tag == "Goo")
        {
            health -= 10;
        }
    }
}
