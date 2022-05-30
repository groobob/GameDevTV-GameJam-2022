using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour
{
    [SerializeField] GameObject bullet;
    [SerializeField] float firerate;
    [SerializeField] float bulletSpeed;
    float cooldown = 0;

    void Update()
    {
        cooldown += Time.deltaTime;
        if(cooldown > firerate)
        {
            GameObject instantiatedBullet = Instantiate(bullet, transform.position - new Vector3(0, 0, 5), transform.rotation);
            Rigidbody2D instantiatedBulletRB = instantiatedBullet.GetComponent<Rigidbody2D>();
            instantiatedBulletRB.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
            Destroy(instantiatedBullet, 10f);
            cooldown -= firerate;
        }
    }
    public void ResetTimer()
    {
        cooldown = 0;
    }
}
