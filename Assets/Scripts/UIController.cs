using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text gameScoreText;
    public GameObject pauseMenu;
    public GameObject gameOverMenu;

	// Use this for initialization
	void Start () {
		
	}
	
    public void OnPauseButtonClicked()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void OnBackButtonClicked()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnRetryButtonClicked()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
        GameObject.FindObjectOfType<GameController>().StopGame();
        GameObject.FindObjectOfType<GameController>().ShowAdForNewGame();
    }

    public void OnMenuButtonClicked()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        Time.timeScale = 1;
        GameObject.FindObjectOfType<GameController>().StopGame();
    }

    // Update is called once per frame
    void Update () {
        gameScoreText.text = GameController.gameScore.ToString();
	}

    public void OnRespawnButtonClicked()
    {
        GameObject.FindObjectOfType<GameController>().ShowAdForRespawn();
    }

    public void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(!gameOverMenu.active);
        Time.timeScale = 1 - Time.timeScale;
    }
}
