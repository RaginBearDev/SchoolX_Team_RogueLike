using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EuroDollars : MonoBehaviour
{
    public int coinAcquired;
    [SerializeField] Text coinsCountText;


    public void Add(int count)
    {
        coinAcquired += count;
        coinsCountText.text = "$" + coinAcquired.ToString();
    }
}
