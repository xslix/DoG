using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_graphics : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.001f);
		
	}
}
