using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{

    public float speed = 5;
    public float attackingDistance = 1;
    public Vector3 direction;
    private Animator animatorEnemy;
    private Rigidbody rigidbodyEnemy;
    private Transform target;
    public bool isFollowingTarget;
    private bool isAttackingTarget;
    private float chasingPlayer = 0.01f;
    public float currentAttackingTime;
    public float maxAttackingTime = 2f;
    void Attack()
    {
        if (!isAttackingTarget)
        {
            return;
        }
    }
        private void FixedUpdate()
        {
            FollowTarget();
        }
        void Start()
        {
            isFollowingTarget = true;
            currentAttackingTime = maxAttackingTime;
            rigidbodyEnemy = GetComponent<Rigidbody>();

            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    
    public void EnemyAttack(int attack)
    {
        if (attack == 1)
        {
            animatorEnemy.SetTrigger("Attack1");
        }
        if (attack == 2)
        {
            animatorEnemy.SetTrigger("Attack2");
        }
        if (attack == 3)
        {
            animatorEnemy.SetTrigger("Attack3");
        }

       
    }


    void Update()
    {
        Attack();
    }

    void FollowTarget()
    {
        if(isFollowingTarget)
        {
            rigidbodyEnemy.isKinematic = true;
        }

        if (Vector3.Distance(transform.position, target.position) >= attackingDistance)
        {
            rigidbodyEnemy.isKinematic = false;

            direction = target.position - transform.position;
            direction.y = 0;

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), 100);

            if (rigidbodyEnemy.velocity.sqrMagnitude != 0)
            {
                rigidbodyEnemy.velocity = transform.forward * speed;
                animatorEnemy.SetBool("Walk", true);
            }
        }
        else if (Vector3.Distance(transform.position, target.position) <= attackingDistance)
        {
            rigidbodyEnemy.isKinematic = false;
            rigidbodyEnemy.isKinematic = false;
            rigidbodyEnemy.velocity = Vector3.zero;
            animatorEnemy.SetBool("Walk", false);
            isFollowingTarget = false;
            isAttackingTarget = true;

        }
    }
} 

 