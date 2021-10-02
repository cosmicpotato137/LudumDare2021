using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public GameObject pauseMenu;

    bool pause = true;

    // Start is called before the first frame update
    void Start()
    {
        Continue();
    }


    // Update is called once per frame
    void Update()
    {
        if (!pause && Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
        else if (pause && Input.GetKeyDown(KeyCode.Escape))
        {
            Continue();
        }
    }

    public void Quit()
    {
        Application.Quit();
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
}
