using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    
    public PlayerMovement PlayerMovement;

    void Awake()
    {
        PlayerMovement.able = true;
        currentHP = maxHP;
        
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
        // Update the HUD here if necessary
    }

    void Update()
    {
        
    }
}