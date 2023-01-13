using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    public void UnpauseGame()
    {
        Time.timeScale = 1f;
    }
}
