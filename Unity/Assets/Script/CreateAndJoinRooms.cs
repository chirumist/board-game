using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{

    private string createInput;
    private string joinInput;

    public void CreateRoom() {
        Debug.Log("On Create Room");
        PhotonNetwork.CreateRoom(createInput);
    }

    public void JoinRoom()
    {
        Debug.Log("On Join Room");
        PhotonNetwork.JoinRoom(joinInput);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("On Joined Room");
        PhotonNetwork.LoadLevel("GameSceane");
    }

    public void ReadCreateInput(string value) {
        createInput = value;
    }

    public void ReadJoinInput(string value) {
        joinInput = value;
    }
}
