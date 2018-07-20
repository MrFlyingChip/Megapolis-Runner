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
    }

    public void StopGame()
    {
        gameSpeed = 0;
        mainMenuUI.SetActive(true);
        backgroundController.minHeight = -0.1f;
        buildingSpawner.CleanBuildings();
        buildingSpawner.SpawnBuildingsForMainMenu();
    }
}
