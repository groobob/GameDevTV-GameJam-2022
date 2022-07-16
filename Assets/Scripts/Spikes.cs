using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput input = collision.gameObject.GetComponent<PlayerInput>();
        PlayerInput.Instance.ResetLevel();
    }
}
