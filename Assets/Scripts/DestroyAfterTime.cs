using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour {

    public float destroyTime;

	// Use this for initialization
	void Start () {
        StartCoroutine(Destroy());
	}
	
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(destroyTime);
        Destroy(gameObject);
    }

	// Update is called once per frame
	void Update () {
		
	}
}
