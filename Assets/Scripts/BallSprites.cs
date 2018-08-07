using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallSprites : MonoBehaviour {

    public int currentSprite;
    public RectTransform spriteContainer;
    public GameObject spritePrefab;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("Ball"))
        {
            PlayerPrefs.SetInt("Ball", 0);
        }
        else
        {
            currentSprite = PlayerPrefs.GetInt("Ball");
        }
        ShowAllSprites();
    }
	
    void ShowAllSprites()
    {
        Sprite[] sprites = Resources.LoadAll<Sprite>("BallSprites/");
        spriteContainer.anchorMax = new Vector2(sprites.Length, 1); 
        for (int i = 0; i < sprites.Length; i++)
        {
            GameObject newSprite = Instantiate(spritePrefab, spriteContainer);
            newSprite.GetComponent<RectTransform>().anchoredPosition = new Vector2();
            newSprite.GetComponent<Image>().sprite = sprites[i];
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
