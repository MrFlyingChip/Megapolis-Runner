using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;


public class GameController : MonoBehaviour {

    public static float gameSpeed = 0;

    public GameObject mainMenuUI;
    public GameObject gameUI;

    public BackgroundController backgroundController;
    public BuildingSpawner buildingSpawner;

    public GameObject ball;
    public Transform ballStartPosition;

    public static int gameScore;

    private void Start()
    {
        AdsController.ShowBanner();
    }

    public void StartGame(ShowResult result)
    {
        gameSpeed = 1;
        gameScore = 0;
        mainMenuUI.SetActive(false);
        gameUI.SetActive(true);
        backgroundController.minHeight = 0.1f;
        ball.transform.position = ballStartPosition.position;
        ball.transform.rotation = Quaternion.Euler(0, 0, 0);
        ball.SetActive(true);
        buildingSpawner.CleanBuildings();
        StartCoroutine(buildingSpawner.Spawner());
        StartCoroutine(GameSpeed());
    }

    public void ShowAdForNewGame()
    {
        if (((PlayerPrefs.GetInt("GamesPlayed") % 5) == 0) && (PlayerPrefs.GetInt("GamesPlayed") != 0))
        {
            AdsController.ShowRewardedAd("video", StartGame);
        }
        else
        {
            StartGame(ShowResult.Failed);
        }
    }

    void Update()
    {
        if(Time.timeScale > 0)
        {
            gameScore += Mathf.FloorToInt(gameSpeed);
        } 
    }

    IEnumerator GameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(4);
            gameSpeed += 0.2f;
        }
    }

    public void PauseGame()
    {
        gameUI.GetComponent<UIController>().ShowGameOverMenu();
    }

    public void ShowAdForRespawn()
    {  
        AdsController.ShowRewardedAd("rewardedVideo", Respawn);
    }

    public void Respawn(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                ball.transform.position = ballStartPosition.position;
                ball.transform.rotation = Quaternion.Euler(0, 0, 0);
                ball.SetActive(true);
                gameUI.GetComponent<UIController>().ShowGameOverMenu();
                break;
            case ShowResult.Failed:
                StopGame();
                break;
            case ShowResult.Skipped:
                StopGame();
                break;
        }
    }

    public void StopGame()
    {
        StopAllCoroutines();
        gameSpeed = 0;
        mainMenuUI.SetActive(true);
        gameUI.SetActive(false);
        backgroundController.minHeight = -0.1f;
        ball.SetActive(false);
        StopCoroutine(buildingSpawner.Spawner());
        buildingSpawner.CleanBuildings();
        buildingSpawner.SpawnBuildingsForMainMenu();
        SaveStatistics();
    }

    void SaveStatistics()
    {
        PlayerPrefs.SetInt("MaxScore", 
            (PlayerPrefs.HasKey("MaxScore") ? Mathf.Max(gameScore, PlayerPrefs.GetInt("MaxScore")) : gameScore));

        PlayerPrefs.SetInt("GamesPlayed",
           (PlayerPrefs.HasKey("GamesPlayed") ?  PlayerPrefs.GetInt("GamesPlayed") + 1 : 1));

        PlayerPrefs.SetInt("SumScore",
           (PlayerPrefs.HasKey("SumScore") ? gameScore + PlayerPrefs.GetInt("SumScore") : gameScore));
    }
}
