using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : TargetScript
{
    public Animator animator;
    public float health = 100f;
    public NavMeshAgent navMeshAgent;

    bool isDead;
    public bool canAttack = true;
    float coolDown = 0.5f;
    Transform target;
    public float damageAmount = 50f;
    float attackTime = 2f;
    float chaseDistance = 2f;
    SpawningEnemy spawn;
    


    public GameObject deadEffect;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        spawn = GameObject.FindGameObjectWithTag("Spawners").GetComponent<SpawningEnemy>();
    }

    // Update is called once per frame
    void Update()
    {

        if(navMeshAgent.remainingDistance < 1 && !isDead)
        {
            animator.SetTrigger("Attack");
        }
        if (isHit && coolDown <= 0 && !isDead)
        {
            Debug.Log("Hit");
            
            health -= 25;
            coolDown = 0.5f;

            if (health <= 0)
            {
                animator.SetTrigger("Dead");
                navMeshAgent.isStopped = true;
                isDead = true;
                StartCoroutine(Dead());
            }
            else
            {
                animator.SetTrigger("Hurt");
                navMeshAgent.isStopped = true;

            }

            isHit = false;
        }

        else if (coolDown <= 0)
        {
            if (!isDead)
            {
                navMeshAgent.isStopped = false;
                navMeshAgent.SetDestination(target.position);
            }
        }

        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }

        

        
    }

    IEnumerator Dead()
    {
        yield return new WaitForSeconds(1.5f);
        GameObject _effect = Instantiate(deadEffect, transform.position, Quaternion.identity);
        Destroy(_effect, 3f);
        Destroy(gameObject);
        spawn.enemiesKilled++;
        spawn.countdown++;

    }
    public void AttackPlayer()
    {
        navMeshAgent.updateRotation = false;
        Vector3 direction = target.position - transform.position;
        direction.y = 0;
        //StartCoroutine(AttackTime());
    }
    //IEnumerator AttackTime()
    //{
        //yield return new WaitForSeconds(0.5f);
        //PlayerHealth.singleton.PlayerDamage(damageAmount);
        //yield return new WaitForSeconds(attackTime);


    //}
        
    
}
