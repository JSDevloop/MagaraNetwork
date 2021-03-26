using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinder : MonoBehaviour
{
    public void SearchGame()
    {
        Network.Emit("searchGame", new {
            name = "Player"
        });
    }
}
