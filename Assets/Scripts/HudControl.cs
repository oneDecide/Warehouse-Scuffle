using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudControl : MonoBehaviour
{
    [SerializeField] private bool closedByDefault = true;
    [SerializeField] private Player player;
    [SerializeField] private Canvas optionsCanvas;
    [SerializeField] private Canvas menuConfirm;
    [SerializeField] private Canvas quitConfirm;
    

    private void Awake()
    {
        if (closedByDefault)
        {
            optionsCanvas.GetComponent<Canvas>().enabled = false;
        }
    }
    
    public void OpenOptions()
    {
        optionsCanvas.GetComponent<Canvas>().enabled = true;
    }

    public void Resume()
    {
        player.ResumeGame();
    }

    public void OpenMenuQuit()
    {
        menuConfirm.enabled = true;
    }

    public void OpenAppQuit()
    {
        quitConfirm.enabled = true;
    }

    public void CloseMenuConfirm()
    {
        menuConfirm.enabled = false;
    }

    public void CloseQuitConfirm()
    {
        quitConfirm.enabled = false;
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame(){
        Application.Quit();
    }
}
