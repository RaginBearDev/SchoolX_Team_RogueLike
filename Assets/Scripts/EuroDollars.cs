using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EuroDollars : MonoBehaviour
{
    [SerializeField] Text coinsCountText;
    private int coinAcquired = SaveController.selectedSave.characterMoney;

    public void Add(int count)
    {
        coinAcquired += count; 
    }

    void Update()
    {
        SaveController.selectedSave.characterMoney = coinAcquired;
        coinsCountText.text = "$" + coinAcquired.ToString();
    }
}
