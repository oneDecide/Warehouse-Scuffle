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
    [SerializeField] public EnemySpawner spawner;
    [SerializeField] public Canvas pauseMenu;
    [SerializeField] public Canvas UICanvas;
    private bool escape;
    private bool pause = false;
    [SerializeField] public AudioSource musicSource;
    [SerializeField] public TMP_Text scoreText;
    [SerializeField] public Canvas TutCanvas;

    [SerializeField] public TMP_Text endScoreText;
    [SerializeField] public Canvas deadCanvas;
    private bool dead;

    private bool started;
    public int score;
    
    private void Start()
    {
        //musicSource.Play();
        dead = false;
        PlayerMovement.able = true;
        currentHP = maxHP;
        PlayerCamera.control = true;
        pauseMenu.enabled = false;
        pause = false;
        UICanvas.enabled = true;
        score = 0;
        TutCanvas.enabled = true;
        started = false;
        endScoreText.enabled = true;
        deadCanvas.enabled = false;
        Time.timeScale = 1f;
        
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0)
        {
            currentHP = 0;
        }
    }

    private void Update()
    {
        
        escape = Input.GetKeyDown(KeyCode.Escape);
        if (escape && !dead)
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
        Time.timeScale = 0f;
        dead = true;
        endScoreText.text = "Score: " + score;
        deadCanvas.enabled = true;
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
        spawner.OnEnemyDefeated();
        spawner.UpdateScore(score);
    }
}