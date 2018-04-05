using UnityEngine;
using System.Collections;

public class BoundingController : MonoBehaviour
{
    #region EnemyDestroy

    public bool EnemyDestroyer = false;


    private void OnEnemyDestroy(IEnemy enemy)
    {
        if (!EnemyDestroyer) return;
        GameObject.Destroy(enemy.gameObject);
    }

    #endregion

    #region BulletDestroyer

    public bool BulletDestroyer = false;


    private void OnBulletDestroy(IBullet bullet)
    {
        if (!BulletDestroyer) return;
        GameObject.Destroy(bullet.gameObject);
    }

    #endregion

    private void OnTriggerExit(Collider other)
    {
        IEnemy enemy = other.gameObject.GetComponent<IEnemy>();
        if (enemy != null)
            OnEnemyDestroy(enemy);

    }


}
