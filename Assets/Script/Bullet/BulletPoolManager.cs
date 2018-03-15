using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour{

    Vector3 poolPositionOutOffScreen = new Vector3(1000, 1000, 1000);

    public GameObject BulletPrefab;
    public int MaxBullet = 20;

    List<IBullet> bullets = new List<IBullet>();

    private void Start()
    {
        for (int i = 0; i < MaxBullet; i++)
        {
            GameObject newGo = Instantiate(BulletPrefab);
            IBullet bullet = newGo.GetComponent<IBullet>();
            if (bullet == null)
            {
                Debug.LogErrorFormat("Il prefab {0} non ha componenti che implementano l'interfaccia IBullet", newGo.name);
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

    /// <summary>
    /// Quando un proiettile all'interno della lista Bullets si disattiva, si disiscrivead entrambi gli eventi
    /// </summary>
    private void OnDisable()
    {
        foreach (BulletStandard bullet in bullets)
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



    public BulletStandard GetBullet(string BulletID)
    {
        foreach (BulletStandard bullet in bullets)
        {
            if (bullet.CurrentState == BulletStandard.State.InPool)
                return bullet;
        }
        Debug.Log("Pool esaurito");
        return null;
    }

}