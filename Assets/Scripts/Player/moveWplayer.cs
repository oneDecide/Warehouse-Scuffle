using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWplayer : MonoBehaviour
{
    [SerializeField] public Transform playerPos;
    
    void Update()
    {
        transform.position = playerPos.position;
    }
}
