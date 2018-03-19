using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyPoolManager : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;
    public int MaxEnemy = 5;

    Vector3 poolPositionOutOffScreen = new Vector3(1000, 1000, 1000);

    List<IEnemy> enemies = new List<IEnemy>();

    private void Start()
    {
        foreach (var enemyPrefab in EnemyPrefabs)
        {
            for (int i = 0; i < MaxEnemy; i++)
            {
                GameObject newGO = Instantiate(enemyPrefab);
                IEnemy enemy = newGO.GetComponent<IEnemy>();
                if (enemy == null)
                {
                    Debug.LogErrorFormat("Il prefab {0} non ha componenti che implementano l'interfaccia IEnemy!", newGO.name);
                    return;
                }
                //Iscrizione ai due eventi
                enemy.OnSpawn += OnEnemySpawn;
                enemy.OnDestroy += OnEnemyDestroy;
                //
                OnEnemyDestroy(enemy);
                enemies.Add(enemy);
            }
        }
    }

    private void OnDisable()
    {
        foreach (IEnemy enemy in enemies)
        {
            enemy.OnSpawn -= OnEnemySpawn;
            enemy.OnDestroy -= OnEnemySpawn;
        }
    }

    void OnEnemySpawn(IEnemy enemy)
    {

    }

    void OnEnemyDestroy(IEnemy enemy)
    {
        enemy.gameObject.transform.position = poolPositionOutOffScreen;
    }

    public IEnemy GetEnemy(string EnemyID)
    {
        foreach (IEnemy enemy in enemies)
        {
            if (enemy.CurrentState == IEnemyState.InPool && enemy.ID == EnemyID)
            {
                return enemy;
            }
        }
        Debug.Log("Enemy Pool esaurito");
        return null;
    }
}
