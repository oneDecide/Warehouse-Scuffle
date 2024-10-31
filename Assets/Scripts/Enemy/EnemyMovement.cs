using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float minMoveInterval = 1f;
    public float maxMoveInterval = 5f;
    public float moveDistance = 5f;

    private Vector3 startPosition;
    private Coroutine moveCoroutine;

    void Start()
    {
        startPosition = transform.position;
        moveCoroutine = StartCoroutine(MoveRandomly());
    }

    private IEnumerator MoveRandomly()
    {
        while (true)
        {
            float waitTime = Random.Range(minMoveInterval, maxMoveInterval);
            yield return new WaitForSeconds(waitTime);

            Vector3 randomDirection = new Vector3(
                Random.Range(-1f, 1f),
                0f, // Keep the movement on the X-Z plane
                Random.Range(-1f, 1f)
            ).normalized;

            Vector3 targetPosition = startPosition + randomDirection * moveDistance;
            while (Vector3.Distance(transform.position, targetPosition) > 0.1f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
                yield return null;
            }
        }
    }
}