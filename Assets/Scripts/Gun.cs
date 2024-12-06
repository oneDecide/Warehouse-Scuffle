using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;
using Random = UnityEngine.Random;

public class Gun : MonoBehaviour
{
    public Transform bulletSpawnPoint;

    public GameObject bulletPrefab;
    
    public TMP_Text ammoCount;

    [SerializeField] public float bulletSpeed = 10;
    [SerializeField] public float rpm = 450;

    [SerializeField]
    public int initialAmmo = 8;

    private int ammo;
    public AudioSource shotSound;
    public AudioSource reloadSound;
    public float audioPitch = .05f;
    public Canvas gunUI;
    public bool makeAble;
    private float timeBetweenShots;
    private float nextTimeToFire = 0f;

    private Animator gunAnims;
    
    
    [SerializeField] public bool fullAuto = false;
    public void Start()
    {
        gunAnims = GetComponent<Animator>();
        makeAble = true;
        timeBetweenShots = 60f / rpm;
        fullAuto = false;
        ammo = initialAmmo;
        updateUI();
    }

    // Update is called once per frame
    void Update()
    {
        makeAble = ammo != 0;
        if (Input.GetButton("Reload"))
        {
            startReload();
        }
        
        
        if (makeAble)
        {
            if (fullAuto)
            {
                if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + timeBetweenShots;
                    Shoot();
                }
            }
            else
            {
                if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire)
                {
                    nextTimeToFire = Time.time + timeBetweenShots;
                    Shoot();
                }
            }
        }
        
    }

    void Shoot()
    {
        if(ammo != 0)
        {
            var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
            bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
            shotSound.pitch = Random.Range(1f - audioPitch, 1f + audioPitch);
            shotSound.Play();
            ammo--;
            updateUI();
            gunAnims.SetBool("Shooting", true);
            gunAnims.Play("Shoot", -1, 0f); 
            reloadSound.Stop();
        }
        else
        {
            startReload();
        }
    }

    public void endShot()
    {
        gunAnims.SetBool("Shooting", false);
    }

    public void endReload()
    {
        gunAnims.SetBool("reloading", false);
    }

    void updateUI()
    {
        ammoCount.text = "AMMO -  " + ammo;
    }

    void startReload()
    {
        makeAble = false;
        gunAnims.Play("reload", -1, 0f);
        gunAnims.SetBool("reloading", true);
        reloadSound.Play();
    }
    void Reload()
    {
        gunAnims.SetBool("reloading", false);
        ammo = initialAmmo;
        updateUI();
        endReload();
        makeAble = true;
    }
}
