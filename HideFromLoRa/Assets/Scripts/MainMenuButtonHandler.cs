using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonHandler : MonoBehaviour
{
    [SerializeField] private GameObject settingsWindow;
    [SerializeField] private GameObject configWindow;

    public void OpenConfigMenu()
    {
        configWindow.SetActive(true);
    }

    public void OpenSettingsMenu()
    {
        settingsWindow.SetActive(true);
    }

    public void CloseMenu()
    {
        configWindow.SetActive(false);
        settingsWindow.SetActive(false);
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("MainGame");
    }
}
