using UnityEngine;
using System.Collections;

public class ShootInput : MonoBehaviour
{
    [Header("Shoot Settings")]
    public KeyCode ShootKey;
    public float ShootForce;
    public Transform ShootPosition;

    BulletPoolManager bulletManager;

    void Start()
    {
        bulletManager = FindObjectOfType<BulletPoolManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(ShootKey))
            Shoot();
    }

    void Shoot()
    {
        Bullet bulletToShoot = bulletManager.GetBullet();
        bulletToShoot.transform.position = ShootPosition.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
    }
}
