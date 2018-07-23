using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSpawner : MonoBehaviour {

    public GameObject buildingPrefab;
    public RectTransform game;

    public List<BuildingController> buildings = new List<BuildingController>();

    public float chanceForHole;

    private void Start()
    {
        SpawnBuildingsForMainMenu();
    }

    public void CleanBuildings()
    {
        foreach (var item in buildings)
        {
            Destroy(item.gameObject);
        }
    }


    public void DestroyBuilding(BuildingController building)
    {
        buildings.Remove(building);
        Destroy(building.gameObject);
    }

    public void SpawnBuildingsForMainMenu()
    {
        CleanBuildings();
        for (int i = 0; i < 4; i++)
        {
            SpawnBuilding(Random.Range(1, 3), i * 0.25f, i);
            buildings[i].TurnOnLightsInFlats();
        }
    }

    public IEnumerator Spawner()
    {
        int number = 0;
        for (int i = 0; i < 8; i++)
        {
            SpawnBuilding(2, i * 0.25f, i);
            number++;
        }
        while (true)
        {
            SpawnBuilding(Random.Range(1, 4), number * 0.25f, buildings.Count);
            number++;
            while (buildings.Count > 15)
            {
                yield return 0;
            }
            yield return new WaitForSeconds(1 / GameController.gameSpeed);
        }
    }
   
    void SpawnBuilding(int floors, float minX, int index)
    {
        GameObject building = Instantiate(buildingPrefab, game);
        RectTransform buildingRect = building.GetComponent<RectTransform>();
        buildingRect.anchorMin = new Vector2(minX, buildingRect.anchorMin.y);
        buildingRect.anchorMax = new Vector2(minX + 0.25f, buildingRect.anchorMax.y);
        buildingRect.anchoredPosition = new Vector2(buildingRect.anchoredPosition.x, 300 * floors);
        float chanceForHoleRandom = Random.Range(0f, 1f);
        if (chanceForHoleRandom > chanceForHole || (index != 0 && buildings[index - 1].hole)) building.GetComponent<BuildingController>().SpawnFlats(floors);
        else
        {
            if (index != 0)
            {
                building.GetComponent<BuildingController>().hole = true;
                building.GetComponent<BuildingController>().floors = buildings[index - 1].floors;
            }     
        }
        buildings.Add(building.GetComponent<BuildingController>());
    }


}
