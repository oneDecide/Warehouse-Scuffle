using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour
{
    public Text enemyCountText;
    public Text hpText;
    private int currentEnemyCount;
    private int displayedEnemyCount;
    private Coroutine updateCoroutine;

    public Player player; // Reference to the Player script

    void Awake()
    {
        InitializeHUD();
        UpdateEnemyCount();
        UpdateHP();
    }

    void Update()
    {
        int newEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (newEnemyCount != currentEnemyCount)
        {
            currentEnemyCount = newEnemyCount;
            if (updateCoroutine != null)
            {
                StopCoroutine(updateCoroutine);
            }
            updateCoroutine = StartCoroutine(DelayedUpdate());
        }
        UpdateHP();
    }

    private IEnumerator DelayedUpdate()
    {
        displayedEnemyCount = currentEnemyCount; // Placeholder count
        enemyCountText.text = "Enemies: " + displayedEnemyCount + "...";

        yield return new WaitForSeconds(1);

        enemyCountText.text = "Enemies: " + currentEnemyCount;
    }

    private void InitializeHUD()
    {
        // Initialize HUD elements
        if (enemyCountText == null || hpText == null)
        {
            GameObject canvas = new GameObject("HUD");
            Canvas c = canvas.AddComponent<Canvas>();
            c.renderMode = RenderMode.ScreenSpaceOverlay;

            // Enemy Count Text
            enemyCountText = new GameObject("EnemyCountText").AddComponent<Text>();
            enemyCountText.transform.SetParent(canvas.transform);
            enemyCountText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            enemyCountText.fontSize = 24;
            enemyCountText.color = Color.white;
            enemyCountText.alignment = TextAnchor.UpperLeft;
            enemyCountText.rectTransform.anchoredPosition = new Vector2(10, -10);

            // HP Text
            hpText = new GameObject("HPText").AddComponent<Text>();
            hpText.transform.SetParent(canvas.transform);
            hpText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            hpText.fontSize = 24;
            hpText.color = Color.white;
            hpText.alignment = TextAnchor.UpperRight;
            hpText.rectTransform.anchoredPosition = new Vector2(-10, -10);
        }
    }

    private void UpdateEnemyCount()
    {
        currentEnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        enemyCountText.text = "Enemies: " + currentEnemyCount;
    }

    private void UpdateHP()
    {
        if (player != null)
        {
            hpText.text = "HP: " + player.currentHP;
        }
    }
}
