using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteController : MonoBehaviour
{
    [SerializeField] GameObject gooPrefab;
    
    private SpitLauncher spitLauncher;
    private bool launchedGoo = false;
    private GameObject player;
    private Animator animator;
    public int health = 50;


    // Start is called before the first frame update
    void Start()
    {
        spitLauncher = GetComponentInChildren<SpitLauncher>();
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponent<BoxCollider>().enabled = false;
            ParasiteSpawner.RemoveParasiteFromList(gameObject);
            Destroy(gameObject, 2f);
        }
        animator.SetInteger("Health", health);
        LookAtPlayer();
        if (spitLauncher.launchSpit && !launchedGoo)
        {
            // var rot = new Quaternion(spitLauncher.transform.rotation.x, spitLauncher.transform.rotation.y + 11f, spitLauncher.transform.rotation.z, spitLauncher.transform.rotation.w);
            GameObject gooInstance = Instantiate(gooPrefab, spitLauncher.transform.position, spitLauncher.transform.rotation);
            gooInstance.GetComponent<Rigidbody>().AddForce(gooInstance.transform.forward * 3f, ForceMode.Impulse);
            Destroy(gooInstance, 2f);

            launchedGoo = !launchedGoo;
        }
        if (spitLauncher.finishedSpit)
            launchedGoo = !spitLauncher.finishedSpit;
    }

    private void LookAtPlayer()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }

    public void PlayFallBackAnimation()
    {
        animator.SetTrigger("GotHit");
    }
}
