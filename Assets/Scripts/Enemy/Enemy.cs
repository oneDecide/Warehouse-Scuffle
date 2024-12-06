using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;
    public AudioSource deathSound;
    private AudioSource audioSource;
    private EnemyMovement enemyMovement;

    void Awake()
    {
        currentHP = maxHP;
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = .2f;
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
        if (collider != null)
        {
            collider.enabled = false;
        }
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        
        if (deathSound != null)
        {
            audioSource.pitch = Random.Range(0.95f, 1.05f); // Slightly vary pitch between 0.95 and 1.05
            audioSource.Play();
        }
        
        Destroy(gameObject, 2.5f);
    }
}