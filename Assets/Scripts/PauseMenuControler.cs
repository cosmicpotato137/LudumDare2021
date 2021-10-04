using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuControler : MonoBehaviour
{
    public GameObject pauseMenu;
    bool pause = false;

    private void Start()
    {
        Continue();
    }

    // Update is called once per frame
    void Update()
    {
        // menu things
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
                Pause();
            else
                Continue();
        }

    }

    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseMenu.SetActive(true);
        pause = true;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pause = false;
    }

    public void MainMenu()
    {
        pause = false;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
