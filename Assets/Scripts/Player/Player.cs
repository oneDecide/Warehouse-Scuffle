using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public bool able;
    public FPSMovement FPSMovement;

    void Awake()
    {
        able = true;
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
        // Handle player movement and actions
        if (able)
        {
            FPSMovement.HandleMovement();
            FPSMovement.HandleJumpAndGravity();
            FPSMovement.HandleDodge();
        }
    }
}