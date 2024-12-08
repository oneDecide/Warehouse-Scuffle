using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    private Player playerScript;
    public AudioSource audioSource;
    public EnemySpawner spawnerScript;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource= gameObject.GetComponent<AudioSource>();
        playerScript = GameObject.Find("Player").GetComponent<Player>();
    }

    public void TakeDamage(int damage)
    {
        Death();
    }

    public void Death()
    {
        MeshRenderer renderer = GetComponent<MeshRenderer>();
        CapsuleCollider collider = GetComponent<CapsuleCollider>();
        playerScript.StartGame();
        playerScript.UpdateScore();
        
        if (collider != null)
        {
            collider.enabled = false;
        }
        if (renderer != null)
        {
            renderer.enabled = false;
        }
        
            audioSource.pitch = Random.Range(0.95f, 1.05f); // Slightly vary pitch between 0.95 and 1.05
            audioSource.Play();
        spawnerScript.StartSpawning();
        Destroy(gameObject, 2.5f);
        
    }
}
