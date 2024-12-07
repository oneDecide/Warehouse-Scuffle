using System;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Enemy : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;
    public AudioSource deathSound;
    private AudioSource audioSource;
    private EnemyMovement enemyMovement;
    public Player playerScript;
    [SerializeField] public ScoreKeeper scoreKeeperScript;

    void Awake()
    {
        currentHP = maxHP;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = .2f;
        
    }

    private void Start()
    {
        playerScript = GameObject.Find("Player").GetComponent<Player>();
        scoreKeeperScript = GameObject.Find("ScoreKeeper").GetComponent<ScoreKeeper>();
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP <= 0)
        {
            currentHP = 0;
            Death();
        }
    }

    public void Death()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        scoreKeeperScript.GainScore();
        playerScript.UpdateScore();
        if (collider != null)
        {
            collider.enabled = false;
        }

        foreach (Transform child in this.transform)
        {
            child.gameObject.SetActive(false);
        }
        audioSource.pitch = Random.Range(0.95f, 1.05f); // Slightly vary pitch between 0.95 and 1.05
        audioSource.Play();
        
        Destroy(gameObject, 2.5f);
    }
}