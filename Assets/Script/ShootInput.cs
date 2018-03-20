using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerData))]
public class ShootInput : MonoBehaviour
{
    [Header("Shoot Settings")]
    public KeyCode ShootKey;
    public float ShootForce;
    public Transform ShootStartPosition;
    public GameObject CurrentBulletGOPrefab;

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
        IBullet currentBullet = CurrentBulletGOPrefab.GetComponent<IBullet>();
        if (currentBullet == null)
            return;
        IBullet bulletToShoot = bulletManager.GetBullet(currentBullet.ID);
        bulletToShoot.gameObject.transform.position = ShootStartPosition.position;
        bulletToShoot.Shoot(transform.forward, ShootForce);
        bulletToShoot.OnDestroy += OnBulletDestroy;
        bulletToShoot.OnEnemyHit += OnEnemyHit;
    }

    public void OnEnemyHit(IEnemy enemyHit, IBullet bullet)
    {
        bullet.OnEnemyHit -= OnEnemyHit;        
        enemyHit.TakeDamage(1);
        playerData.Score += enemyHit.Score;
    }

    public void OnBulletDestroy(IBullet bullet)
    {
        bullet.OnEnemyHit -= OnEnemyHit;
        bullet.OnDestroy -= OnBulletDestroy;
    }
}
