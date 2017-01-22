using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitcher : MonoBehaviour {

    public GameObject light;
    public bool isDay = true;
    public bool isNight = false;
    public float DayLen = 10;
    float switchTime =0 ;     
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time-switchTime>DayLen)
        {
            if (isDay)
            {
                isDay = false;
                isNight = true;
                light.GetComponent<Light>().intensity = 0.2f;
            }
            else
            {
                isDay = true;
                isNight = false;
                light.GetComponent<Light>().intensity = 1.8f;
            }
            switchTime = Time.time;

        }
	}
}
