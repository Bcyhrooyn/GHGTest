using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
