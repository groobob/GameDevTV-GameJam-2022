using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] GameObject player;
    private PlayerInput playerInputScript;
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            playerInputScript.ResetLevel();
        }
    }
}
