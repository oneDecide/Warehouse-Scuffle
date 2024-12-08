using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    private Transform player;
    private Transform[] patrolPoints;
    private Transform currentTarget;
    public AudioSource shotSound;

    public GameObject enemyBulletPrefab;
    public Transform enemyBulletSpawn;

    private float timeBetweenAttacks = 1f;
    private bool alreadyAttacked;

    public float sightRange = 20f; 
    public float attackRange = 20f; 

    private bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        // Automatically find the player in the scene
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
        else
        {
            Debug.LogError("Player with tag 'Player' not found!");
        }

        // Automatically find patrol points in the scene
        GameObject patrolParent = GameObject.FindGameObjectWithTag("PatrolPoints");
        if (patrolParent != null)
        {
            patrolPoints = new Transform[patrolParent.transform.childCount];
            for (int i = 0; i < patrolParent.transform.childCount; i++)
            {
                patrolPoints[i] = patrolParent.transform.GetChild(i);
            }
        }
        else
        {
            Debug.LogError("No GameObject with tag 'PatrolPoints' found!");
        }

        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check if the player is in sight or attack range
        playerInSightRange = player != null && Vector3.Distance(transform.position, player.position) <= sightRange;
        playerInAttackRange = player != null && Vector3.Distance(transform.position, player.position) <= attackRange;

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange || playerInAttackRange) ChaseAndAttackPlayer();
    }

    private void Patroling()
    {
        // Move to the next patrol point if no target is set or destination is reached
        if (currentTarget == null || agent.remainingDistance < 0.5f)
        {
            ChooseRandomPatrolPoint();
        }
    }

    private void ChaseAndAttackPlayer()
    {
        // Chase the player
        if (player != null)
        {
            agent.SetDestination(player.position);
            // Enable fast turning when chasing the player
            agent.updateRotation = false; // Disable NavMeshAgent's auto-rotation
            Vector3 direction = (player.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
            // Attack if in range
            if (playerInAttackRange && !alreadyAttacked)
            {
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        if (enemyBulletPrefab != null && enemyBulletSpawn != null)
        {
            // Spawn and shoot the bullet
            var bullet = Instantiate(enemyBulletPrefab, enemyBulletSpawn.position, enemyBulletSpawn.rotation);
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * 75f;
            shotSound.Play();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void ChooseRandomPatrolPoint()
    {
        if (patrolPoints.Length > 0)
        {
            // Select a random patrol point that is valid on the NavMesh
            for (int i = 0; i < patrolPoints.Length; i++)
            {
                Transform randomPoint = patrolPoints[Random.Range(0, patrolPoints.Length)];
                if (NavMesh.SamplePosition(randomPoint.position, out NavMeshHit hit, 1.0f, NavMesh.AllAreas))
                {
                    currentTarget = randomPoint;
                    agent.SetDestination(hit.position);
                    return;
                }
            }

            Debug.LogWarning("No valid patrol points found on the NavMesh!");
        }
        else
        {
            Debug.LogWarning("Patrol points array is empty!");
        }
    }
}
