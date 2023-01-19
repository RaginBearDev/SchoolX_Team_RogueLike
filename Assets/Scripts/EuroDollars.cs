using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EuroDollars : MonoBehaviour
{
    [HideInInspector] public int coinAcquired = SaveController.selectedSave.characterMoney;
    [SerializeField] Text coinsCountText;


    public void Add(int count)
    {
        coinAcquired += count;
        coinsCountText.text = "$" + coinAcquired.ToString();
    }
}
