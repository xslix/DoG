using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkStart : Photon.MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("TestRoom", new RoomOptions(), TypedLobby.Default);

    }

    void OnJoinedRoom()
    {
        PhotonNetwork.Instantiate("man", new Vector3(0f, 0f, 0f), Quaternion.identity, 0);
    }
}
