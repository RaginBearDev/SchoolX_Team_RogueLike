﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SaveController : MonoBehaviour
{
    public void Save(SaveData savedData) {
         string jsonString = JsonUtility.ToJson(savedData);

        FileInfo[] filesInDirectory = getFilesinDirectory();
        if (filesInDirectory.Length == 3) {
            File.Delete(filesInDirectory[2].FullName);
            saveInFileSystem(jsonString, savedData.characterName);
        } else {
            saveInFileSystem(jsonString, savedData.characterName);
        }
    }

    public SaveData[] Load() {
        FileInfo[] filesInDirectory = getFilesinDirectory();
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

    public SaveData initSaveData(string characterName, string startLevelName) {
        SaveData newSaveData = new SaveData();
        newSaveData.characterLevel = 1;
        newSaveData.characterName = characterName;
        newSaveData.characterMoney = 0;
        newSaveData.levelName = startLevelName;

        return newSaveData;
    }

    private FileInfo[] getFilesinDirectory() {
        DirectoryInfo directory = new DirectoryInfo(Application.dataPath + "/Saves");
        return directory.GetFiles("*.json");
    }

    private void saveInFileSystem(string jsonString, string fileName) {
        File.WriteAllText(Application.dataPath + "/Saves/" + fileName + ".json", jsonString);
    }


    [System.Serializable]
    public class SaveData {
        public string levelName;
        public string characterName;
        public int characterLevel;
        public int characterMoney;
    }
}

