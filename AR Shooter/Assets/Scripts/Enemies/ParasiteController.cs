using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteController : MonoBehaviour
{
    [SerializeField] GameObject gooPrefab;
    
    public GameObject player {get;set;}

    private SpitLauncher spitLauncher;
    private bool launchedGoo = false;
    private Animator animator;
    private bool dead = false;
    
    public int health = 50;


    // Start is called before the first frame update
    void Start()
    {
        spitLauncher = GetComponentInChildren<SpitLauncher>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !dead)
        {
            GetComponent<BoxCollider>().enabled = false;
            dead = true;
            ParasiteSpawner.RemoveParasiteFromList(gameObject);
            Score.AddPointsToScore();

            Destroy(gameObject, 2f);
        }
        animator.SetInteger("Health", health);

        if (player == null)
            return;

        LookAtPlayer(player);
        SpitAtPlayer();
    }

    private void SpitAtPlayer()
    {
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

    private void LookAtPlayer(GameObject player)
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
