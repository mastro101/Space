using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAsteroid : EnemyBase {


    public override void MovementBehaviour()
    {
        if (CurrentState == IEnemyState.InUse)
        {
            transform.position += new Vector3(0, 0, -1) * MovementSpeed;
        }
    }

}
