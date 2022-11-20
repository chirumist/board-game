using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class SpawnPlayer : MonoBehaviour
{
    public GameObject playerPrefab;

    public float minZ;
    public float minY;
    public float minX;
    public float maxZ;
    public float maxY;
    public float maxX;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 rendomPosition = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        PhotonNetwork.Instantiate(playerPrefab.name, rendomPosition, Quaternion.identity, 0);
    }
}
