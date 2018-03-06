using UnityEngine;
using System.Collections;

public class EnemyStatistic : MonoBehaviour
{
    
    public float MovementSpeed;
    public float LeftLimit, RightLimit;
    public bool goLeft, goRight;
    public int Life;

    public void Death()
    {
        if (Life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
