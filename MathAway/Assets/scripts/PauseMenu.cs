using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void ResetGame()
    {
        GameObject.Find("Dificulty").gameObject.GetComponent<difficulty>().SetValues(0,0,0);
        GameObject.Find("Results").gameObject.GetComponent<Results>().ResetResults(0, 0, 0, 0,0,0);
        FindObjectOfType<AudioManager>().Stop("Background");
        FindObjectOfType<AudioManager>().Play("Background");
        Time.timeScale = 1f;
        
        SceneManager.LoadScene("MainScreen");
        pauseMenuUI.SetActive(false);
        GameIsPaused = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
