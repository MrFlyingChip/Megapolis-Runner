using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour {
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector2(-GameController.gameSpeed * Time.deltaTime, 0f));
	}
}
