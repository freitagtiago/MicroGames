using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform _target = null;
    [SerializeField] float _turnSpeed = 5f;
    NavMeshAgent navMeshAgent = null;
    float _chaseRange = 13f;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;
    float attackRange = 2f;
    Animator animator;
    bool isAlive = true;

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(!isAlive)
        {
            enabled = false;
            navMeshAgent.enabled = false;
            return;
        }
        distanceToTarget = Vector3.Distance(transform.position, _target.position);

        if (isProvoked && (distanceToTarget <= attackRange))
        {
            Attack();
        }
        else if (isProvoked || (distanceToTarget <= _chaseRange))
        {
            isProvoked = true;
            ChaseTarget();
        }
        else
        {
            animator.SetTrigger("isIdle");
            isProvoked = false;
        }
    }

    private void ChaseTarget()
    {
        animator.SetBool("isAttacking", false);
        animator.SetTrigger("isMoving");
        navMeshAgent.SetDestination(_target.position);
    }

    private void Attack()
    {
        animator.SetBool("isAttacking",true);
        Debug.Log("Attacking");
    }
    private void Die()
    {
        animator.SetTrigger("isDead");
        isAlive = false;
        Debug.Log("Dying");
    }

    public void OnDamageTaken()
    {
        isProvoked = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
