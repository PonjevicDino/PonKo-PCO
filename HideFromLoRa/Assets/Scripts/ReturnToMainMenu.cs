using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMainMenu : MonoBehaviour
{
    private bool triggeredExit = true;
    private int triggerCounter = 0;

    void FixedUpdate()
    {
        if (triggeredExit)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                SceneManager.LoadScene("MainMenu");
            }
            else if (triggerCounter > 0) triggerCounter--;
            else triggeredExit = false;
        }

        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            triggeredExit = true;
            triggerCounter = 50;
            BluetoothService.Toast("Return to main menu -> Press again!");
        }
    }
}
