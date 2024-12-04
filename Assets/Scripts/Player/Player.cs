using System;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    
    public PlayerMovement PlayerMovement;
    [SerializeField] public PlayerCamera PlayerCamera;
    [SerializeField] public Canvas pauseMenu;
    private bool escape;
    private bool pause = false;
    
    private void Start()
    {
        PlayerMovement.able = true;
        currentHP = maxHP;
        PlayerCamera.control = true;
        pauseMenu.enabled = false;
        pause = false;
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

    private void Update()
    {
        escape = Input.GetKeyDown(KeyCode.Escape);
        if (escape)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        if (pause)
        {
            ResumeGame();
            return;
        }
        
        pause = true;
        pauseMenu.enabled = true;
        Time.timeScale = 0f;
        PlayerMovement.able = false;
        PlayerCamera.control = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pause = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
        PlayerMovement.able = true;
        PlayerCamera.control = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}