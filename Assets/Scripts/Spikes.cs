using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        PlayerInput input = collision.gameObject.GetComponent<PlayerInput>();
        PlayerInput.Instance.ResetLevel();
    }
}
