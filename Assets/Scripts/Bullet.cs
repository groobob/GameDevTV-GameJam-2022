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

    void OnCollisionEnter2D()
    {

    }
}
