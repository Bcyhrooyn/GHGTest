using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PauseMenu pauseMenu;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape"))
        {
            TogglePauseMenu();
        }
	}

    public void TogglePauseMenu()
    {
        if (pauseMenu.GetComponentInChildren<Canvas>().enabled)
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = false;
            Time.timeScale = 1.0f;
        }
        else
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = true;
            Time.timeScale = 0.0f;
        }
    }
}
