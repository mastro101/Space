using UnityEngine;
using System.Collections;

public class EnemyStatistic : MonoBehaviour
{

    public bool IsAlive = true;
    public int ScoreValue;
    public float MovementSpeed;
    public float LeftLimit, RightLimit;
    public bool goLeft, goRight;
    public int Life;

    public void TakeDamage(int damage = 1)
    {
        Life = 0;
    }


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
