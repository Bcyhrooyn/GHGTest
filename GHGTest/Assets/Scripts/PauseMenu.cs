using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class PauseMenu : MonoBehaviour {

    [SerializeField]
    private GameManager GM;
    [SerializeField]
    public Button selectableButton;

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
        EventSystem.current.GetComponent<EventSystem>().SetSelectedGameObject(null);
    }
}
