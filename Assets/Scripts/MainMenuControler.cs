using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    public GameObject optionsMenu;
    public GameObject mainMenu;

    bool showOptions;

    private void Start()
    {
        ExitOptions();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (showOptions)
            {
                ExitOptions();
                showOptions = false;
            }
            else
            {
                Options();
                showOptions = true;
            }
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Options()
    {
        showOptions = true;
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }

    public void ExitOptions()
    {
        showOptions = false;
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
