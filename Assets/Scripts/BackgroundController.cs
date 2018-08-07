using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BackgroundController : MonoBehaviour {

    public Color dawnColor;
    public Color morningColor;
    public Color middayColor;
    public Color eveningColor;
    public Color sunsetColor;
    public Color nightColor;

    public float currentHour;
    public Image background;

    public Sprite[] cloudsSprites;
    public GameObject cloudPrefab;

    public float minHeight;
    public int maxTime;
    // Use this for initialization
    void Start () {
        background = GetComponent<Image>();
        LoadCurrentTime();
        StartCoroutine(Timer());
        StartCoroutine(CloudSpawner());
    }
	
    void LoadCurrentTime()
    {
        currentHour = System.DateTime.Now.Hour;
        currentHour += (System.DateTime.Now.Minute) / 60.0f; 
        SetSkyColor();
    }

    void SetSkyColor()
    {
        if(currentHour >= 6 && currentHour < 9)
        {
            background.color = Color.Lerp(dawnColor, morningColor, (currentHour - 6) / 3);
        } 
        else if (currentHour >= 9 && currentHour < 12)
        {
            background.color = Color.Lerp(morningColor, middayColor, (currentHour - 9) / 3);
        }
        else if (currentHour >= 12 && currentHour < 19)
        {
            background.color = Color.Lerp(middayColor, eveningColor, (currentHour - 12) / 7);
        }
        else if (currentHour >= 19 && currentHour < 20)
        {
            background.color = Color.Lerp(eveningColor, sunsetColor, (currentHour - 19) / 1);
        }
        else if (currentHour >= 20 && currentHour < 21)
        {
            background.color = Color.Lerp(sunsetColor, nightColor, (currentHour - 20) / 1);
        }
        else if (currentHour >= 21 || currentHour < 3)
        {
            background.color = nightColor;
        }
        else if (currentHour >= 3 && currentHour < 6)
        {
            background.color = Color.Lerp(nightColor, dawnColor, (currentHour - 3) / 3);
        }
    }

    IEnumerator Timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            currentHour += 1 / 60.0f;
            if (currentHour >= 24) currentHour = 0;
            SetSkyColor();
        }
    }

    IEnumerator CloudSpawner()
    {
        while (true)
        {
            int cloudSpawnTime = Random.Range(0, maxTime);
            yield return new WaitForSeconds(cloudSpawnTime);
            GameObject cloud = Instantiate(cloudPrefab, transform);
            cloud.GetComponent<Image>().sprite = cloudsSprites[Random.Range(0, cloudsSprites.Length)];
            float size = Random.Range(0.8f, 1.4f);
            cloud.transform.localScale = new Vector3(size, size, size);
            Rect thisRect = gameObject.GetComponent<RectTransform>().rect;
            cloud.GetComponent<RectTransform>().anchoredPosition = new Vector2(thisRect.width, Random.Range(thisRect.height * minHeight, thisRect.height * 0.4f));
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
