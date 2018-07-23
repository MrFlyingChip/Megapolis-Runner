using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static float gameSpeed = 0;

    public GameObject mainMenuUI;
    public BackgroundController backgroundController;
    public BuildingSpawner buildingSpawner;

	public void StartGame()
    {
        gameSpeed = 1;
        mainMenuUI.SetActive(false);
        backgroundController.minHeight = 0.1f;
        buildingSpawner.CleanBuildings();
        StartCoroutine(buildingSpawner.Spawner());
        StartCoroutine(GameSpeed());
    }
    
    IEnumerator GameSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            gameSpeed += 0.1f;
        }
        Physics.
    }

    public void StopGame()
    {
        StopCoroutine(GameSpeed());
        gameSpeed = 0;
        mainMenuUI.SetActive(true);
        backgroundController.minHeight = -0.1f;
        buildingSpawner.CleanBuildings();
        buildingSpawner.SpawnBuildingsForMainMenu();
        StopCoroutine(buildingSpawner.Spawner());
    }
}
