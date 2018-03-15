using UnityEngine;
using System.Collections;

public class BaseEnemy : EnemyStatistic
{

    private void Start()
    {
        Life = 1;
        transform.position = new Vector3(-18f, 0, 15f);
        goRight = true;
    }

    private void Update()
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

    private void FixedUpdate()
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
