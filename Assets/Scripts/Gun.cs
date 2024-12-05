using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;

    public float bulletSpeed = 10;
    public AudioSource shotSound;
    public float audioPitch = .05f;
    public Canvas gunUI;
    public bool able;

    public void Start()
    {
        able = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (able)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
                shotSound.pitch = Random.Range(1f - audioPitch, 1f + audioPitch);
                shotSound.Play();
            }
        }
        
    }
}
