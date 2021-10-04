using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControler : MonoBehaviour
{
    public static GameControler instance;

    [Header("Player")]
    public Transform playerSpawn;
    public GameObject player;

    [Header("Level")]
    public Collider2D levelCompleteTrigger;
    public bool levelComplete;

    GameObject playerInstance;

    private void Awake()
    {
        if (instance = null)
            instance = gameObject.GetComponent<GameControler>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer(.5f);
    }


    // Update is called once per frame
    void Update()
    {
        // restart level
        if (Input.GetKeyDown(KeyCode.R))
            RestartLevel();

        // next level
        if (levelComplete && !playerInstance.GetComponent<PlayerControler>().dead)
            NextLevel();
    }

    public void Quit()
    {
        Application.Quit();
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

    public void RestartLevel()
    {
        GameObject[] goArray = FindObjectsOfType(typeof(GameObject)) as GameObject[];
        foreach (GameObject g in goArray)
        {
            if (g.layer == LayerMask.NameToLayer("Spawner"))
                g.GetComponent<HazardSpawner>().ResetTrigger();
            else if (g.layer == LayerMask.NameToLayer("Hazard"))
                Destroy(g);
        }
        levelCompleteTrigger.gameObject.GetComponent<LevelCompleteTrigger>().triggered = false;
        levelComplete = false;

        SpawnPlayer();
    }

    public void NextLevel()
    {
        StartCoroutine(NextLevelCo());
    }

    IEnumerator NextLevelCo()
    {
        yield return new WaitForSeconds(1.0f);
        int cs = SceneManager.GetActiveScene().buildIndex;
        string cn = SceneManager.GetActiveScene().name;
        if (cn != "Level 10")
            SceneManager.LoadScene(cs + 1);
        else
            SceneManager.LoadScene("MainMenu");
    }
}
