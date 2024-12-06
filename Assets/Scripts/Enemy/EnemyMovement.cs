using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform player;
    public LayerMask whatIsGround, whatIsPlayer;

    public Vector3 walkpoint;
    private bool walkPointSet;
    public float walkPointRange;

    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player_1").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
        
    }

    private void Patroling()
    {
        
    }

    private void ChaseAndAttackPlayer()
    {
        
    }
}