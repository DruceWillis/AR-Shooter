using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ZombieController : MonoBehaviour
{
    // [SerializeField] GameObject player;

    public bool attacking;
    public int health = 50;

    private Animator animator;
    private GameObject player;
    private bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPlayer();
        ChasePlayer();
        if (health <= 0 && !dead)
        {
            PlayFallBackAnimation();
            dead = !dead;
            // StartCoroutine(ResetZombieSpawner());
            Destroy(gameObject, 2f);
        }
    }

    private void LookAtPlayer()
    {
        Vector3 targetPosition = player.transform.position;
        targetPosition.y = transform.position.y;
        transform.LookAt(targetPosition);
    }

    public void ChasePlayer()
    {
        var playerPos = player.transform.position;
        var distBetweenZombieAndPlayer = Vector3.Distance(playerPos, transform.position);

        if (distBetweenZombieAndPlayer > 1.75f)
        {
            attacking = false;
            animator.SetBool("ChasePlayer", true);
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Z_Run"))
                print("Running");
            playerPos.y = transform.position.y;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, 0.5f * Time.deltaTime);
        }
        else
        {
            animator.SetBool("ChasePlayer", false);
            StartCoroutine(TransitionBeforeAttack());
        }

    }
    
    void OnDestroy()
    {
        FindObjectOfType<ParasiteSpawner>().spawnedZombie = false;
    }

    // IEnumerator ResetZombieSpawner()
    // {
    //     yield return new WaitForSeconds(2f);
        
    // }

    IEnumerator TransitionBeforeAttack()
    {
        yield return new WaitForSeconds(.5f);
        attacking = true;
    }

    public void PlayFallBackAnimation()
    {
        animator.SetTrigger("GotHit");
    }

}
