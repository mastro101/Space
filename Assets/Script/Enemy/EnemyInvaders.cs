using UnityEngine;
using System.Collections;
using System;

public class EnemyInvaders : EnemyBase
{

    public override void MovementBehaviour()
    {
        if (CurrentState == IEnemyState.InUse)
        {

            if (transform.position.x > RightLimit.position.x)
            {
                goRight = false;
                goLeft = true;
                transform.position += new Vector3(0, 0, -1f);
            }
            else if (transform.position.x < LeftLimit.position.x)
            {
                goLeft = false;
                goRight = true;
                transform.position += new Vector3(0, 0, -1f);
            }

            if (goRight)
            {
                transform.position += Vector3.right * MovementSpeed;
            }
            else if (goLeft)
            {
                transform.position += Vector3.left * MovementSpeed;
            }
        }
    }

}
