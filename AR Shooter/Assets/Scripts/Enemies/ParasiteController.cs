using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParasiteController : MonoBehaviour
{
    [SerializeField] GameObject gooPrefab;
    
    public GameObject fireEffect;
    public GameObject target {get;set;}

    private SpitLauncher spitLauncher;
    private Animator animator;
    private bool launchedGoo = false;
    private bool dead = false;
    private Rigidbody rigidbody;
    
    public int health = 50;


    // Start is called before the first frame update
    void Start()
    {
        spitLauncher = GetComponentInChildren<SpitLauncher>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = Vector3.zero;
        HandleDeath();

        if (target == null)
            return;

        LookAtPlayer(target);
        SpitAtPlayer();
    }

    private void HandleDeath()
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
    }

    private void SpitAtPlayer()
    {
        if (spitLauncher.launchSpit && !launchedGoo)
        {
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

    public void SetOnFire()
    {
        fireEffect.SetActive(true);
    }

    public void KnockBack()
    {
        if (target != null)
        {
            Vector3 moveDirection = transform.position - target.transform.position;
            print(moveDirection);
            rigidbody.AddForce(moveDirection * 500f, ForceMode.Impulse);
        }
    }
}
