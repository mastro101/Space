using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerData))]
public class ShootInput : MonoBehaviour
{
    [Header("Shoot Settings")]
    public KeyCode ShootKey;
    public float ShootForce;
    public Transform ShootPosition;
    public GameObject CurrentBulletGO;

    BulletPoolManager bulletManager;
    PlayerData playerData;

    void Start()
    {
        bulletManager = FindObjectOfType<BulletPoolManager>();
        playerData = GetComponent<PlayerData>();
    }


    void Update()
    {
        if (Input.GetKeyDown(ShootKey))
            Shoot();
    }

    void Shoot()
    {
        IBullet currentBullet = CurrentBulletGO.GetComponent<IBullet>();
        if (currentBullet == null)
            return;
        IBullet bulletToShoot = bulletManager.GetBullet(currentBullet.ID);
        bulletToShoot.gameObject.transform.position = ShootPosition.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
        bulletToShoot.OnDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyHit += OnEnemyHit;
    }

    public void OnEnemyHit(EnemyStatistic enemyHit, IBullet bullet)
    {
        bullet.OnEnemyHit -= OnEnemyHit;        
        enemyHit.TakeDamage();
        playerData.Score += enemyHit.ScoreValue;
    }

    public void OnBulletDestroy(IBullet bullet)
    {
        bullet.OnEnemyHit -= OnEnemyHit;
        bullet.OnDestroy -= OnBulletDestroy;
    }
}
