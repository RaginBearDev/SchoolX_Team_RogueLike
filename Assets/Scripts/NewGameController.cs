using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NewGameController : MonoBehaviour
{
    public string newGameLevel;
    public InputField characterNameField;
    public SaveController saveController;

    public void Init() {
        SaveController.SaveData newSaveData = saveController.initSaveData(characterNameField.text, newGameLevel);
        saveController.Save(newSaveData);
        SceneManager.LoadScene(newGameLevel);
    }
}
