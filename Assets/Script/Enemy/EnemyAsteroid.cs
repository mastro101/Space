using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid : EnemyBase {

    protected override string getID()
    {
        return "EnemyAsteroid";
    }

    private void Update()
    {
        if (CurrentState == IEnemyState.InUse)
        {
            transform.position += new Vector3(0, 0, -1) * MovementSpeed;
        }
    }
}
