using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor_graphics : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.001f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
