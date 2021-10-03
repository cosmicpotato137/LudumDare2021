using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{

    [Header("Player")]
    public Transform playerSpawn;
    public GameObject player;

    [Header("Hazards")]
    public GameObject[] spawners;

    [Header("Menu")]
    public GameObject pauseMenu;
    public GameObject optionsMenu;

    bool pause = false;
    bool options = false;
    GameObject playerInstance;

    // Start is called before the first frame update
    void Start()
    {
        ExitOptions();
        Continue();

        SpawnPlayer(.5f);
    }


    // Update is called once per frame
    void Update()
    {
        // menu things
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!pause)
                Pause();
            else if (pause && options)
                ExitOptions();
            else
                Continue();
        }

        // restart level
        if (Input.GetKeyDown(KeyCode.R))
            SpawnPlayer(0.0f);
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

    public void SpawnPlayer(float seconds = 0.0f)
    {
        StartCoroutine(SpawnPlayerCo(seconds));
    }

    IEnumerator SpawnPlayerCo(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        if (playerInstance) Destroy(playerInstance);
        playerInstance = Instantiate(player, playerSpawn);
    }
}
