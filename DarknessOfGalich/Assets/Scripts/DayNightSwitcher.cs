using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightSwitcher : Photon.MonoBehaviour {

    public GameObject light;
    public bool isDay = true;
    public bool isNight = false;
    public float dayDuration = 10;
    float switchTime = 0;
    public AudioSource Rooster;
    public AudioSource Wolf;

    // Use this for initialization
	void Start () {
    }


    // Update is called once per frame
    void Update()
    {

        if (Time.time - switchTime > dayDuration && PhotonNetwork.isMasterClient)
        {

            if (isDay)
                photonView.RPC("DayNightSW", PhotonTargets.All);
            else
                photonView.RPC("NightDaySW", PhotonTargets.All);

        }
    }
        
    

    [PunRPC]
    void DayNightSW()
    {
        Wolf.Play();
        isDay = false;
        isNight = true;
        switchTime = Time.time;
        StartCoroutine("switchDayToNight");
    }

    [PunRPC]
    void NightDaySW()
    {
        Rooster.Play();
        isDay = true;
        isNight = false;
        switchTime = Time.time;
        StartCoroutine("switchNightToDay");
    }

    IEnumerator switchDayToNight()
    {
        while (light.GetComponent<Light>().intensity > 0.4f)
        {
            light.GetComponent<Light>().intensity -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
    IEnumerator switchNightToDay()
    {
        while (light.GetComponent<Light>().intensity < 1.8f)
        {
            light.GetComponent<Light>().intensity += 0.1f;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
