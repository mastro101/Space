using UnityEngine;

public interface IEnemy
{
    string ID { get; }
    int Score { get; }
    Transform LeftLimit { get; }
    Transform RightLimit { get; }
    GameObject gameObject { get; }
    IEnemyState CurrentState { get; set; }

    void Spawn();
    void DestroyMe();
    void TakeDamage(int damage);
    void MovementBehaviour();
    void ShootBehaviour();
    

    event IEnemyEvents.EnemyEvent OnSpawn;
    event IEnemyEvents.EnemyEvent OnDestroy;

}

public class IEnemyEvents
{
    public delegate void EnemyEvent(IEnemy enemy);
}

public enum IEnemyState
{
    InPool,
    Destroying,
    InUse,
}