using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;
    public AudioClip deathSound;
    private AudioSource audioSource;
    private CharacterController controller; // Assuming you're using CharacterController for movement

    void Awake()
    {
        currentHP = maxHP;
        audioSource = gameObject.AddComponent<AudioSource>();
        controller = GetComponent<CharacterController>(); // If using a CharacterController
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
        // Disable movement
        if (controller != null)
        {
            controller.enabled = false;
        }

        // Disable the MeshRenderer
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        if (renderer != null)
        {
            renderer.enabled = false;
        }

        // Play the death sound with slight varying pitch
        if (deathSound != null)
        {
            audioSource.clip = deathSound;
            audioSource.pitch = Random.Range(0.95f, 1.05f); // Slightly vary pitch between 0.95 and 1.05
            audioSource.Play();
        }

        // Handle additional death logic
        Debug.Log(gameObject.name + " has died.");
    }
}