﻿using UnityEngine;

public interface IEnemy
{
    string ID { get; }
    int Score { get; }
    float LeftLimit { get; }
    float RightLimit { get; }
    GameObject gameObject { get; }
    IEnemyState CurrentState { get; set; }

    void Spawn();
    void DestroyMe();
    void TakeDamage(int damage);
    

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