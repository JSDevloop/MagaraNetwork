using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public TextMesh nameText;
    NetworkObject networkObject => GetComponent<NetworkObject>();
    void Start()
    {
        nameText.text = gameObject.name;
        if(networkObject.isMine) Camera.main.GetComponent<CameraMovement>().target = transform;
    }
    void Update()
    {
        nameText.transform.rotation = Quaternion.LookRotation(nameText.transform.position - Camera.main.transform.position);
    }
}
