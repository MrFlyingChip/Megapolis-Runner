using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class MainMenuController : MonoBehaviour {

    public GameController gameController;

    public void OnPlayButtonClicked()
    {
        gameController.ShowAdForNewGame();
    }
}
