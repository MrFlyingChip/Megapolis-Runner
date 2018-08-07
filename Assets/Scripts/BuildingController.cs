using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : MonoBehaviour {

    public GameObject flatPrefab;

    public List<FlatController> flats = new List<FlatController>();

    public bool hole;

    public int floors;

	// Use this for initialization
	void Start () {
    }
	
    public void SpawnFlats(int flatsNumber)
    {
        floors = flatsNumber;
        RectTransform thisTransform = GetComponent<RectTransform>();
        for (int i = 0; i < flatsNumber + 5; i++)
        {
            GameObject flat = Instantiate(flatPrefab, thisTransform);
            flats.Add(flat.GetComponent<FlatController>());
            flat.GetComponent<FlatController>().building = this;
            flat.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, -300 * i);
        }
    }

    public void TurnOnLightsInFlats()
    {
        foreach (var flat in flats)
        {
            flat.TurnLightsOn();
        }
    }

	// Update is called once per frame
	void Update () {
        if(transform.position.x < -10)
        {
            FindObjectOfType<BuildingSpawner>().DestroyBuilding(this);
        }
	}
}
