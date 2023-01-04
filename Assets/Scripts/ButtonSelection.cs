using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelection : MonoBehaviour
{
    public Button startButton;

    void Start()
    {
        startButton = startButton.GetComponent<Button>();

        startButton.Select();
    }
    
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            EventSystem.current.SetSelectedGameObject(
                this.gameObject
            );
        }
    }

    public void selectButton() {
        startButton.Select();
    }
}
