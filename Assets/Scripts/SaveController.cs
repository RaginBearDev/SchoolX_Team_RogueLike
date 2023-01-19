using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    public static SaveController Instance = null;
    public static SaveData selectedSave;

    void Awake() {
        DontDestroyOnLoad(this.gameObject);
        if (Instance == null) {
            Instance = this;
        } else if(Instance != null) {
            Destroy(this.gameObject);
        }
    }

    public void Save(SaveData savedData) {
         string jsonString = JsonUtility.ToJson(savedData);

        FileInfo[] filesInDirectory = GetFilesinDirectory();
        if (filesInDirectory.Length == 3) {
            File.Delete(filesInDirectory[2].FullName);
            SaveInFileSystem(jsonString, savedData.characterName);
        } else {
            SaveInFileSystem(jsonString, savedData.characterName);
        }
    }

    public SaveData[] Load() {
        FileInfo[] filesInDirectory = GetFilesinDirectory();
        SaveData[] saves = new SaveData[3];

        int iteration = 0;  
        foreach(FileInfo file in filesInDirectory) {
            if(file.Extension.Contains(".json")) {
                string jsonSaveDateFileText = File.ReadAllText(file.FullName);
                SaveData jsonSaveData = JsonUtility.FromJson<SaveData>(jsonSaveDateFileText);
                saves[iteration] = jsonSaveData;
            }

            iteration++;
        }

        return saves;
    }

    public SaveData InitSaveData(string characterName, string startLevelName) {
        SaveData newSaveData = new SaveData();
        newSaveData.characterLevel = new Level(1, 0);
        newSaveData.characterName = characterName;
        newSaveData.characterMoney = 0;
        newSaveData.levelName = startLevelName;

        return newSaveData;
    }

    public void SetSelectedSave(SaveData save) {
        selectedSave = save;
    }

    public void UpdateCharacterSaveStats(Level level, EuroDollars euroDollars) {
        SaveController.selectedSave.characterLevel = level;
        SaveController.selectedSave.characterMoney = euroDollars.coinAcquired;
    }

    private FileInfo[] GetFilesinDirectory() {
        DirectoryInfo directory = new DirectoryInfo(Application.dataPath + "/Saves");
        return directory.GetFiles("*.json");
    }

    private void SaveInFileSystem(string jsonString, string fileName) {
        File.WriteAllText(Application.dataPath + "/Saves/" + fileName + ".json", jsonString);
    }

    [System.Serializable]
    public class SaveData {
        public string levelName;
        public string characterName;
        public Level characterLevel;
        public int characterMoney;
    }
}

