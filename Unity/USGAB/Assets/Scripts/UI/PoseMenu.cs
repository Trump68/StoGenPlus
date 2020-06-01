using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PoseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject Volume;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;       
    }

    public void LoadMenu()
    {
        //Debug.Log("Loading menu...");
        //SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        //Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void SetTimeScale(float timescale)
    {
        //Debug.Log(timescale);
        var caption = Volume.GetComponent<Text>();
        caption.text = $"Timescale: {timescale} secs in 1 game sec";
        WorldTime.TimeScale = timescale;
    }
}
