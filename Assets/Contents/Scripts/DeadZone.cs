using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameStateManager.instance.SetCurrentGameState(GameStateManager.GameStates.GameOver);
        }
    }
}