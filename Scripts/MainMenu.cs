using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public CanvasGroup OptionPanel;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene("SettingMenu");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {   //When click quit game will close 
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void BackButton()
    {
        OptionPanel.alpha = 0;
        OptionPanel.blocksRaycasts = false;
    }
}