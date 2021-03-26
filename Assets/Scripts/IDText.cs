using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IDText : MonoBehaviour
{
    void Start()
    {
        GetComponent<Text>().text = Network.playerID;   
    }
}
