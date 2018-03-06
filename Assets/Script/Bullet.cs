using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public State CurrentState = State.InPool;

    public BulletEvent OnShoot;
    public BulletEvent OnDestroy;

    private void OnCollisionEnter(Collision collision)
    {
        if (CurrentState == State.InUse)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyStatistic>().Life--;
            }
            DestroyMe();
        }
    }

    private void Update()
    {
        if (CurrentState == State.InUse)
        {
            transform.position += direction * force;
        }
    }

    #region API

    #region Shoot

    Vector3 direction;
    float force;

    public void Shoot(Vector3 _direction, float _force)
    {
        CurrentState = State.InUse;
        if (OnShoot != null)
            OnShoot(this);
        direction = _direction;
        force = _force;
    }

    #endregion

    public void DestroyMe()
    {
        CurrentState = State.InPool;
        if (OnDestroy != null)
            OnDestroy(this);
    }

    #endregion


    #region Dichiarazioni tipi

    public delegate void BulletEvent(Bullet bullet);

    public enum State
    {
        InPool,
        InUse,
    }

    #endregion
}
