using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_controller : Photon.MonoBehaviour {

    public int speed;
    Vector3 oldPos = Vector3.zero;
    Vector3 newPos = Vector3.zero;
    float offsetTime = 0f;
    bool isSinch = false;
    // Use this for initialization
	void Start () {
        
		
	}
	
	// Update is called once per frame
	void Update () {
        if (photonView.isMine)
        {
            transform.position += Vector3.Normalize(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0)) * speed * Time.deltaTime;
            Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y+2f, -100);
        }
        else if (isSinch)
        {
            offsetTime += Time.deltaTime * 9.0f;
            transform.position = Vector3.Lerp(oldPos, newPos, offsetTime);
        }
		
	}

    void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        Vector3 pos = transform.position;
        stream.Serialize(ref pos);
        if (stream.isReading)
        {
            oldPos = transform.position;
            newPos = pos;
            offsetTime = 0;
            isSinch = true;
        }
    }
}
