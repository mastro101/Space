using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour{

    public Bullet BulletPrefab;
    public int MaxBullet = 20;

    List<Bullet> bullets = new List<Bullet>();

    public Bullet GetBullet()
    {
        Bullet returnBullet = null;
        return returnBullet;
    }
}