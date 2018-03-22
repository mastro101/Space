using UnityEngine;

public interface IBullet {

    string ID { get; }
    GameObject gameObject { get; }
    IBulletState CurrentState { get; set; }


    void DestroyBehaviour();
    void Shoot(Vector3 _direction, float _force);

    event IBulletEvents.BulletEvent OnShoot;
    event IBulletEvents.BulletEvent OnDestroy;
    event IBulletEvents.EnemyHit OnEnemyHit;

    
}

public class IBulletEvents {

    public delegate void BulletEvent(IBullet bullet);

    public delegate void EnemyHit(IEnemy enemy, IBullet bullet);

}

public enum IBulletState
{
    InPool,
    Destroying,
    InUse,
}
