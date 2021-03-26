using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetworkChecker : MonoBehaviour
{
    public int returnSceneIndex = 0;
    Network network;
    void Awake()
    {
        network = FindObjectOfType<Network>();
    }
    void Start()
    {
        if(network == null) SceneManager.LoadScene(returnSceneIndex);
    }
}
