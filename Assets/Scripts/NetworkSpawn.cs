using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkSpawn : MonoBehaviour
{
    public GameObject prefab;
    void Start()
    {
        Network.Instantiate(prefab, transform.position, Vector3.zero, Network.playerID);
    }
}
