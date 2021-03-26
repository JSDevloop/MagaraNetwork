using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkObject : MonoBehaviour
{
    public int id;
    public bool isMine;
    void Start()
    {
        id = ServerManager.networkObjects++;
    }
}
