using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class RoomEvent : MonoBehaviour
{
    public UnityEvent onRoomStarted;
    void Start()
    {
        Network.When("startRoom", (data) => {
            Debug.Log("wwoooww");
            onRoomStarted.Invoke();
        });
    }

    public void DefaultRoomStarted(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
