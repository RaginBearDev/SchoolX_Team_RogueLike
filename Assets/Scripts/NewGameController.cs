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
        SaveController.SaveData newSaveData = saveController.InitSaveData(characterNameField.text, newGameLevel);
        saveController.Save(newSaveData);
        saveController.SetSelectedSave(newSaveData);
        SceneManager.LoadScene(newGameLevel);
    }
}
