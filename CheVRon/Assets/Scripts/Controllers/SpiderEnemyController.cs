using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpiderEnemyController : MonoBehaviour
{
    public float lookRadius;
    public float attackingRadius;
    public GameObject enemyObject;
    public ScoringSystem scoringSys;
    public EnemyTracker enemyTracker;
    public EnemySpawner enemySpawner;
    public int points;

    private bool isDead = false;
    private EnemyTracker.EnemyType enemyType;
    private new Rigidbody rigidbody;

    Transform target;
    NavMeshAgent agent;
    Animator animator;
    AudioSource audioSrc;



    void Start()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>(); 
        audioSrc = GetComponent<AudioSource>();
        enemyType = EnemyTracker.EnemyType.Spider;

    }

    public EnemyTracker.EnemyType GetEnemyType()
    {
        return enemyType;
    }

    public bool GetIsDead()
    {
        return this.isDead;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "LiveAmmo")
        {
            animator.SetBool("GetHit", true);
            isDead = true;
            StopMovement();
            Debug.Log("Enemy hit");
            SpawnIfRequired();
            AddPoints();
            Die();
        }
    }

    private void SpawnIfRequired()
    {
        if (enemyTracker.GetNumSpider() < 3)
        {
            enemySpawner.Populate();
        }
    }

    private void AddPoints()
    {
        scoringSys.GetComponent<ScoringSystem>().UpdateScore(points);
    }

    private void Die()
    {
        enemyTracker.DecrementSpider();
        audioSrc.Play();
        Destroy(enemyObject, 2.0f);

    }

    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            FaceTarget();
            agent.SetDestination(target.position);
            animator.SetBool("WithinSpottingDistance", true);

            if (distance <= attackingRadius)
            {
                FaceTarget();
                Attack();
            }
        }

        else
        {
            animator.SetBool("WithinSpottingDistance", false);
        }
    }

    private void Attack()
    {
        animator.SetTrigger("WithinAttackingDistance");
    }

    private void StopMovement()
    {
        rigidbody.isKinematic = true;
        rigidbody.velocity = Vector3.zero;
        rigidbody.angularVelocity = Vector3.zero;
    }

    private void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);

    }
}
