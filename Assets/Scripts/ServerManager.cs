using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Quobject.SocketIoClientDotNet.Client;
using UnityEngine.UI;
public class ServerManager : MonoBehaviour
{
    public string url = "http://localhost:3000/";
    public static Socket socket;
    public static int networkObjects;
    void Awake()
    {
        if (socket == null)
        {
            socket = IO.Socket(url);
        }
    }
}