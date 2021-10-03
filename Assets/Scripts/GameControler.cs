using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{

    [Header("Player")]
    public Transform playerSpawn;
    public GameObject player;

    [Header("Menu")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    bool pause = false;
    bool options = false;

    // Start is called before the first frame update
    void Start()
    {
        ExitOptions();
        Continue();

        GameObject.Instantiate(player, playerSpawn);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
                Pause();
            else if (pause && options)
                ExitOptions();
            else
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
        options = false;
    }

    public void Continue()
    {
        Time.timeScale = 1.0f;
        pauseMenu.SetActive(false);
        pause = false;
        options = false;
    }

    public void Options()
    {
        options = true;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitOptions()
    {
        options = false;
        pauseMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }    

    public void MainMenu()
    {
        options = false;
        pause = false;
        pauseMenu.SetActive(false);
        optionsMenu.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }
}
