using UnityEngine;

public interface IBullet {

    string ID { get; }
    GameObject gameObject { get; }
    State CurrentState { get; set; }


    void DestroyMe();
    void Shoot(Vector3 _direction, float _force);

    event IBulletEvents.BulletEvent OnShoot;
    event IBulletEvents.BulletEvent OnDestroy;
    event IBulletEvents.EnemyHit OnEnemyHit;

    
}

public class IBulletEvents {

    public delegate void BulletEvent(IBullet bullet);

    public delegate void EnemyHit(EnemyStatistic enemy, IBullet bullet);

}

public enum State
{
    InPool,
    Destroying,
    InUse,
}
