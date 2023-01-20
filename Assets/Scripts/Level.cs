using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {   
    [SerializeField] ExpBar expBar;
    [SerializeField] Character character;
    private int level = SaveController.selectedSave.characterLevel;
    private int exp = SaveController.selectedSave.characterExp;

    int TO_LEVEL_UP{
        get{
            return level * 1000;
        }
    }

    
    public void AddExperience(int amount)
    {
        exp += amount;
        CheckLevelUp();
        expBar.UpdateExpSlider(exp, TO_LEVEL_UP);
    }

    
    private void CheckLevelUp()
    {
        if(exp >= TO_LEVEL_UP){
            exp -= TO_LEVEL_UP;
            level += 1;
            expBar.SetLevelText(level);
            character.Heal((int)(character.maxHp*0.25));
            character.maxHp += 1;
        }
    }

    
    void Start()
    {
        expBar.UpdateExpSlider(exp, TO_LEVEL_UP);
        expBar.SetLevelText(level);
    }

    void Update()
    {
        SaveController.selectedSave.characterLevel = level;
        SaveController.selectedSave.characterExp = exp;
    }
}
