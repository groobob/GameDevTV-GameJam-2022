using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("urmommy");
        PlayerInput input = collision.gameObject.GetComponent<PlayerInput>();
        if (input != null)
        {
            Debug.Log("pog!");
            PlayerInput.Instance.ResetLevel();
            Destroy(gameObject);
        }
        else
        {

        }
    }
}
