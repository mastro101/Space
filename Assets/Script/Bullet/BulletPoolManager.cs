using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour{

    Vector3 poolPositionOutOffScreen = new Vector3(1000, 1000, 1000);

    public delegate void BulletManagerEvent(IBullet _IBullet);

    public static BulletManagerEvent OnBulletInGame;

    public GameObject[] BulletPrefabs;
    public int MaxBullet = 20;

    List<IBullet> bullets = new List<IBullet>();

    private void Start()
    {
        foreach (var bulletPrefab in BulletPrefabs)
        {
            for (int i = 0; i < MaxBullet; i++)
            {
                GameObject newGO = Instantiate(bulletPrefab);
                IBullet bullet = newGO.GetComponent<IBullet>();
                if (bullet == null)
                {
                    Debug.LogErrorFormat("Il prefab {0} non ha componenti che implementano l'interfaccia IBullet!", newGO.name);
                    return;
                }
                //Iscrizione ai due eventi
                bullet.OnShoot += OnBulletShoot;
                bullet.OnDestroy += OnBulletDestroy;
                //
                OnBulletDestroy(bullet);
                bullets.Add(bullet);
            }
        }
    }

    /// <summary>
    /// Quando un proiettile all'interno della lista Bullets si disattiva, si disiscrive ad entrambi gli eventi
    /// </summary>
    private void OnDisable()
    {
        foreach (IBullet bullet in bullets)
        {
            bullet.OnShoot -= OnBulletShoot;
            bullet.OnDestroy -= OnBulletDestroy;
        }
    }

    private void OnBulletShoot(IBullet bullet)
    {

    }

    private void OnBulletDestroy(IBullet bullet)
    {
        // move bullet
        bullet.gameObject.transform.position = poolPositionOutOffScreen;
    }



    public IBullet GetBullet(string BulletID)
    {
        foreach (IBullet bullet in bullets)
        {
            if (bullet.CurrentState == IBulletState.InPool && bullet.ID == BulletID)
            {
                if (OnBulletInGame == null)
                    OnBulletInGame(bullet);
                return bullet;
            }
        }
        Debug.Log("Bullet Pool esaurito");
        return null;
    }

}