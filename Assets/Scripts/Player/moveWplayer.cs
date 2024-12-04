using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWplayer : MonoBehaviour
{
    [SerializeField] public Transform playerPos;
    private Vector3 velocity = Vector3.zero;
    private float smoothTime = 0.05f;
    
    void Update()
    {
        Vector3 targetPosition = playerPos.position;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
