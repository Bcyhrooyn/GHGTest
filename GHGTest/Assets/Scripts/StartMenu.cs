using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

    public void OnStartButtonClicked()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }
}
