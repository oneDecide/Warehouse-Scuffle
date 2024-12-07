using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;
    
    public PlayerMovement PlayerMovement;
    [SerializeField] public PlayerCamera PlayerCamera;
    [SerializeField] public ScoreKeeper scoreKeeperScript;
    [SerializeField] public Canvas pauseMenu;
    [SerializeField] public Canvas UICanvas;
    private bool escape;
    private bool pause = false;
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public Canvas TutCanvas;

    private bool started;
    public int score;
    
    private void Start()
    {
        //musicSource.Play();
        PlayerMovement.able = true;
        currentHP = maxHP;
        PlayerCamera.control = true;
        pauseMenu.enabled = false;
        pause = false;
        UICanvas.enabled = true;
        score = 0;
        TutCanvas.enabled = true;
        started = false;
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
        //musicSource.Pause();
        TutCanvas.enabled = false;
        UICanvas.enabled = false;
        pause = true;
        pauseMenu.enabled = true;
        Time.timeScale = 0f;
        PlayerMovement.able = false;
        PlayerCamera.control = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void StartGame()
    {
        TutCanvas.enabled = false;
        started = true;
    }

    public void Death()
    {
        Debug.Log("The Player Has Died");
        Time.timeScale = .2f;
        PlayerMovement.able = false;
        PlayerCamera.control = false;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        //musicSource.UnPause();
        if(started == false)
            TutCanvas.enabled = true;
        UICanvas.enabled = true;
        pause = false;
        pauseMenu.enabled = false;
        Time.timeScale = 1f;
        PlayerMovement.able = true;
        PlayerCamera.control = true;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void UpdateScore()
    {
        score = scoreKeeperScript.GetScore();
        scoreText.text = "Score:  " + score;
    }
}