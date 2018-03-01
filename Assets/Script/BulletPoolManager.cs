using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour{

    Vector3 poolPositionOutOffScreen = new Vector3(1000, 1000, 1000);

    public Bullet BulletPrefab;
    public int MaxBullet = 20;

    List<Bullet> bullets = new List<Bullet>();

    private void Start()
    {
        for (int i = 0; i < MaxBullet; i++)
        {
            Bullet bulletToAdd = Instantiate(BulletPrefab);
            //Iscrizione ai due eventi
            bulletToAdd.OnShoot += OnBulletShoot;
            bulletToAdd.OnDestroy += OnBulletDestroy;
            //
            OnBulletDestroy(bulletToAdd);
            bullets.Add(bulletToAdd);
        }
    }

    private void OnDisable()
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.OnShoot -= OnBulletShoot;
            bullet.OnDestroy -= OnBulletDestroy;
        }
    }

    private void OnBulletShoot(Bullet bullet)
    {

    }

    private void OnBulletDestroy(Bullet bullet)
    {
        // move bullet
        bullet.transform.position = poolPositionOutOffScreen;
    }



    public Bullet GetBullet()
    {
        foreach (Bullet bullet in bullets)
        {
            if (bullet.CurrentState == Bullet.State.InPool)
                return bullet;
        }
        Debug.Log("Pool esaurito");
        return null;
    }

}