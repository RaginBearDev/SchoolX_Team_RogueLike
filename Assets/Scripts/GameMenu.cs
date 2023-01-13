using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMenu : MonoBehaviour
{

    [SerializeField] GameObject panel;
    [SerializeField] GameObject background;
    [SerializeField] PauseManager pauseManager;
    [SerializeField] GameObject playerStatsUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(panel.activeInHierarchy == false) {
                OpenMenu();
            } else {
                CloseMenu();
            }
        }
    }

    public void CloseMenu() {
        panel.SetActive(false);
        background.SetActive(false);
        playerStatsUI.SetActive(true);
        pauseManager.UnpauseGame();
    }

    public void OpenMenu() {
        playerStatsUI.SetActive(false);
        background.SetActive(true);
        panel.SetActive(true);
        pauseManager.PauseGame();
    }

    public void BackToMenu() {
        pauseManager.UnpauseGame();
        SceneManager.LoadScene("MainMenu");
    }
}
