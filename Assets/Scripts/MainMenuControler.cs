using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControler : MonoBehaviour
{
    public bool showOptions;
    public GameObject optionsMenu;
    public GameObject mainMenu;


    private void Start()
    {
        ExitOptions();
    }

    private void Update()
    {
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
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
