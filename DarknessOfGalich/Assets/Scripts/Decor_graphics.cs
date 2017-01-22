using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor_graphics : MonoBehaviour {

    public bool isTree = false;
    float windTime = 0;
    Vector3 scl;
    // Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y * 0.001f);
        if (isTree) scl = transform.localScale*Random.Range(0.65f,1.35f);
       
    }
	
	// Update is called once per frame
	void Update () {
        transform.localScale = scl + new Vector3(1f,1f,1f)* (Camera.main.transform.position.y - transform.position.y) * 0.015f;
        if (Time.time - windTime > 3)
        {
            windTime = Time.time;

            if (Random.Range(0f, 5f) < 1f) GetComponent<Animator>().SetTrigger("wind");
        }
		
	}
}
