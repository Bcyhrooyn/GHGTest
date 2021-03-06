﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour {

    public PauseMenu pauseMenu;
    public PauseMenu gameOverMenu;
    public PauseMenu victoryMenu;
    public ScrollingObject[] backgrounds;
    public VictoryTrigger victoryTrigger;
    public FlyingObstacle instructionText;
    public Robo player;

    private AudioSource audioSource;
    private TextMesh text;
    private bool isGameStarted = false;

    [SerializeField]
    float scrollSpeed = -7;

    [SerializeField]
    float startupTime = 3.4f;

	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
        text = instructionText.GetComponent<TextMesh>();
    }

    // Update is called once per frame
    void Update () {
		if ((Input.GetKeyDown("escape") || Input.GetKeyDown(KeyCode.Joystick1Button7) )&& !gameOverMenu.GetComponentInChildren<Canvas>().enabled)
        {
            TogglePauseMenu();
        }
        if (!isGameStarted)
        {
            startupTime -= Time.deltaTime * 2;
            text.text = Mathf.Round(startupTime).ToString();
            if (text.text == "0")
            {
                text.text = "GO!";
                isGameStarted = true;
                StartGame();
            }

        }
	}

    private void StartGame()
    {
        audioSource.Play();
        foreach (FlyingObstacle obstacle in GetComponentsInChildren<FlyingObstacle>())
        {
            obstacle.scrollSpeed = scrollSpeed;
        }
        foreach (ScrollingObject scroll in backgrounds)
        {
            scroll.scrollSpeed = scrollSpeed;
            scroll.StartScroll();
        }
        player.SetIsMoving(true);
        victoryTrigger.scrollSpeed = scrollSpeed;
        instructionText.scrollSpeed = scrollSpeed;
    }


    public void TogglePauseMenu()
    {
        if (pauseMenu.GetComponentInChildren<Canvas>().enabled)
        {
            pauseMenu.GetComponentInChildren<Canvas>().enabled = false;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            Time.timeScale = 1.0f;
            if (isGameStarted)
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

    public void CloseGameOverMenu()
    {
        if (gameOverMenu.GetComponentInChildren<Canvas>().enabled)
        {
            gameOverMenu.GetComponentInChildren<Canvas>().enabled = false;
            EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
            Time.timeScale = 1.0f;
        }
    }

    public void OpenGameOverMenu()
    {
        if (!gameOverMenu.GetComponentInChildren<Canvas>().enabled)
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
