using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public static List<Bullet> Bullets = new List<Bullet>();

    void Awake()
    {
        Bullets.Add(this);
    }

    void OnDestroy()
    {
        Bullets.Remove(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerInput input = collision.gameObject.GetComponent<PlayerInput>();
        if (input != null)
        {
            PlayerInput.Instance.ResetLevel();
            Destroy(gameObject);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
