using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private Transform target;
    public GameObject[] healthItems;
    public NavMeshAgent agent;
    private Animator animator;
    public static bool isAttacking = false;

    public float EnemeyHealth = 50f;
    public float lookRadius = 10f;
    public float takeDamage;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        target = PlayerMovement.Instance.transform;
    }
    private void Update()
    {
        EnemyAttack();
    }
    public void EnemyDead(int damage)
    {
        EnemeyHealth -= damage;

        if (EnemeyHealth <= 0)
        {
            isAttacking = false;
            Destroy(gameObject);
            Instantiate(healthItems[Random.Range(0, healthItems.Length)], transform.position, transform.rotation);
        }
    }

    public void EnemyAttack()
    {
        float distance = Vector3.Distance(transform.position, target.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            animator.SetBool("Walk", true);

            if (distance <= agent.stoppingDistance)
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Attack", true);
                isAttacking = true;
                SurvivalManager.instance.TakeDamage(takeDamage);
            }
            else
            {
                animator.SetBool("Attack", false);
                isAttacking = false;
            }
        }
        else
        {
            animator.SetBool("Walk", false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
