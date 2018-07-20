using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour {

    public float maxSpeed;
    public float minSpeed;

    float speed;
    // Use this for initialization
    void Start () {
        speed = Random.Range(minSpeed, maxSpeed);
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(new Vector3(-speed * Time.deltaTime, 0f));
	}
}
