using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControler : MonoBehaviour
{
    public bool mRunning;

    // Start is called before the first frame update
    void Start()
    {
        mRunning = true;   
    }

    // Update is called once per frame
    void Update()
    {
        if (!mRunning)
            Quit();


    }

    void Quit()
    {
        Application.Quit();
    }
}
