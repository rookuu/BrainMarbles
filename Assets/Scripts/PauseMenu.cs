﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

/* The ingame pause menu, allows the user to restart and quit the level. */

public class PauseMenu : MonoBehaviour {

    public GameObject PauseUI;

    public bool paused = false;

    void Start()
    {
        PauseUI.SetActive(false);
    }
    void Update()
    {
        if (Input.GetButtonDown("Pause"))
        {
            paused = !paused;
        }

        if (paused)
        {
            PauseUI.SetActive(true);
            Time.timeScale = 0;
        }
        if (!paused)
        {
            PauseUI.SetActive(false);
            Time.timeScale = 1;
        }
    }
    public void Resume()
    {
        paused = false;
    }

    public void Restart()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void MainMenu()
    {
        Application.LoadLevel(4);
    }
}
