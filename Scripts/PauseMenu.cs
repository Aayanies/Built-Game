using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class PauseMenu : MonoBehaviour
{
    public GameObject Panel;
    // Start is called before the first frame update
    void Start()
    {
       
    }
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!Panel.activeSelf)
            {
                Time.timeScale = 0f;
                Panel.SetActive(true);
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;
            }
            else
            {
                Time.timeScale = 1f;
                Panel.SetActive(false);
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
    public static void Quit()
    {
        Application.Quit();
    }
 
    public static void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }
    public void Resume()
    {
        Time.timeScale=1f;
        Panel.SetActive(false);
        Cursor.visible=false;
        Cursor.lockState = CursorLockMode.Locked;
    }
   
}
