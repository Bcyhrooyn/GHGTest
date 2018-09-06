using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private GameManager GM;

    public void OnQuitButtonClicked()
    {
        Application.Quit();
    }

    public void OnContinueButtonClicked()
    {
        GM.TogglePauseMenu();
    }

    public void OnPlayAgainButtonClicked()
    {
        GM.ToggleGameOverMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
