//using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public float SpawnRate;
    public Transform SpawnPosition;
    public GameObject CurrentEnemyGO;

    EnemyPoolManager enemyManager;
    float nextSpawn = 1;

    private void Start()
    {
        enemyManager = FindObjectOfType<EnemyPoolManager>();
    }

    private void Update()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + SpawnRate;
            Spawn();
        }
    }

    private void Spawn()
    {
        CurrentEnemyGO = enemyManager.EnemyPrefabs[Random.Range(0, enemyManager.EnemyPrefabs.Length)];
        IEnemy currentEnemy = CurrentEnemyGO.GetComponent<IEnemy>();
        if (currentEnemy == null)
            return;
        IEnemy EnemyToSpawn = enemyManager.GetEnemy(currentEnemy.ID);
        EnemyToSpawn.gameObject.transform.position = new Vector3(Random.Range(currentEnemy.RightLimit.position.x, currentEnemy.LeftLimit.position.x), 0, SpawnPosition.position.z);
        EnemyToSpawn.Spawn();
        
    }
}
