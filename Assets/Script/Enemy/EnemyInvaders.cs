using UnityEngine;
using System.Collections;
using System;

public class EnemyInvaders : EnemyBase
{
    protected override string getID()
    {
        return "EnemyInvaders";
    }


    private void Update()
    {
        if (CurrentState == IEnemyState.InUse)
        {
            if (transform.position.x > RightLimit)
            {
                goRight = false;
                goLeft = true;
                transform.position += new Vector3(0, 0, -1f);
            }
            else if (transform.position.x < LeftLimit)
            {
                goLeft = false;
                goRight = true;
                transform.position += new Vector3(0, 0, -1f);
            }
        }
    }

    private void FixedUpdate()
    {
        if (CurrentState == IEnemyState.InUse)
        {
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
