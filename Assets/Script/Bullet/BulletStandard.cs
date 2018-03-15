using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandard : BulletBase {


    protected override string getID()
    {
        return "BulletStandard";
    }

    private void OnCollisionEnter(Collision collision)
    {
        EnemyStatistic enemyHit;

        if (CurrentState == State.InUse)
        {
            enemyHit = collision.gameObject.GetComponent<EnemyStatistic>();
            if (enemyHit)
            {
                if (OnEnemyHit != null)
                {
                    OnEnemyHit(enemyHit, this);
                }
            }
            DestroyMe();
        }
    }

    


}
