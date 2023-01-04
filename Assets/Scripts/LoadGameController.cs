using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadGameController : MonoBehaviour
{
    public SaveController saveController;

    public GameObject savesWrapper;

    public GameObject NewGameMenu;

    public GameObject LoadGameMenu;

    private string levelToLoad;

    void Start() {
        SaveController.SaveData[] saves = saveController.Load();
            
        for (int i = 0; i < saves.Length; i++) {
            GameObject saveButton = savesWrapper.transform.GetChild(i).gameObject;
            Button save = saveButton.GetComponent<Button>();

            GameObject usernameGameObject = saveButton.transform.GetChild(0).gameObject;
            GameObject levelGameObject = saveButton.transform.GetChild(1).gameObject;
            GameObject startNewGameObject = saveButton.transform.GetChild(2).gameObject;

            if (saves[i] != null) {
                Text username = usernameGameObject.GetComponent<Text>();
                Text level = levelGameObject.GetComponent<Text>();

                username.text = saves[i].characterName;
                level.text = saves[i].characterLevel.ToString();

                levelToLoad = saves[i].levelName;
                save.onClick.AddListener(LoadLevel);
            } else {
                usernameGameObject.SetActive(false);
                levelGameObject.SetActive(false);
                startNewGameObject.SetActive(true);
                save.onClick.AddListener(ShowNewGameMenu);
                
            }
        }
        
    }

    private void ShowNewGameMenu() {
        LoadGameMenu.SetActive(false);
        NewGameMenu.SetActive(true);
    }

    private void LoadLevel() {
        SceneManager.LoadScene(levelToLoad);
    
    }
}
