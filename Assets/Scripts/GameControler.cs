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
    
    GameObject playerInstance;

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
            SpawnPlayer(0.0f);
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
}
