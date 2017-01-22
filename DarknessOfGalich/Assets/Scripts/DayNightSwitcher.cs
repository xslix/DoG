using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitcher : MonoBehaviour {

    public GameObject light;
    public bool isDay = true;
    public float dayDuration = 60;
    float currentTime = 0;     
    // Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        StartCoroutine("DynamicDayNight");
	}

    IEnumerator DynamicDayNight()
    {
        if (currentTime % (dayDuration * 2) <= dayDuration)
        {
            isDay = true;
        } else
        {
            isDay = false;
        }
        if (isDay)
        {
            float coef = Mathf.Abs(dayDuration / 2 - currentTime % (dayDuration * 2));
            light.GetComponent<Light>().intensity = 1.8f - 2.4f * coef / dayDuration;
        } else
        {
            float coef = Mathf.Abs(dayDuration * 3 / 2 - currentTime % (dayDuration * 2));
            light.GetComponent<Light>().intensity = 1.2f * coef / dayDuration;
        }
        currentTime = Time.time;
        yield return null;
    }
}
