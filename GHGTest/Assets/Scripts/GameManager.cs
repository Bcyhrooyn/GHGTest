using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public PauseMenu pauseMenu;
    public PauseMenu gameOverMenu;
    public PauseMenu victoryMenu;
    private AudioSource audioSource;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("escape") && !gameOverMenu.GetComponentInChildren<Canvas>().enabled)
        {
            TogglePauseMenu();
        }
	}

    public void TogglePauseMenu()
    {
        if (pauseMenu.GetComponentInChildren<Canvas>().enabled)
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = false;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            Time.timeScale = 1.0f;
            audioSource.Play();
        }
        else
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = true;
            pauseMenu.selectableButton.Select();
            Time.timeScale = 0.0f;
            audioSource.Pause();
        }
    }

    public void ToggleGameOverMenu()
    {
        if (gameOverMenu.GetComponentInChildren<Canvas>().enabled)
        {
            gameOverMenu.GetComponentInChildren<Canvas>().enabled = false;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            Time.timeScale = 1.0f;
        }
        else
        {
            gameOverMenu.GetComponentInChildren<Canvas>().enabled = true;
            gameOverMenu.selectableButton.Select();
            Time.timeScale = 0.0f;
            audioSource.Pause();
        }
    }

    public void ToggleVictoryMenu()
    {
        if (victoryMenu.GetComponentInChildren<Canvas>().enabled)
        {
            victoryMenu.GetComponentInChildren<Canvas>().enabled = false;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            Time.timeScale = 1.0f;
        }
        else
        {
            victoryMenu.GetComponentInChildren<Canvas>().enabled = true;
            victoryMenu.selectableButton.Select();
            Time.timeScale = 0.0f;
            audioSource.Pause();
        }
    }
}
