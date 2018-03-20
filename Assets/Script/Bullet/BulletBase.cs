using UnityEngine;
using System.Collections;
using System;

public abstract class BulletBase : MonoBehaviour, IBullet
{
    protected IBulletState _currentState = IBulletState.InPool;

    public IBulletState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }


    public string ID { get { return getID(); } }

    protected abstract string getID();

    public event IBulletEvents.BulletEvent OnShoot;
    public event IBulletEvents.BulletEvent OnDestroy;
    public event IBulletEvents.EnemyHit OnEnemyHit;

    #region Events

    protected void InvockOnShoot()
    {
        if (OnShoot != null)
            OnShoot(this);
    }

    protected void InvockOnDestroy()
    {
        if (OnDestroy != null)
            OnDestroy(this);
    }

    protected void InvockOnEnemyHit(IEnemy enemy)
    {
        if (OnEnemyHit != null)
            OnEnemyHit(enemy, this);
    }

    #endregion

    #region Shoot

    Vector3 direction;
    float force;

    public virtual void Shoot(Vector3 _direction, float _force)
    {
        CurrentState = IBulletState.InUse;
        InvockOnShoot();
        direction = _direction;
        force = _force;
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }

    private void OnFixedUpdate()
    {
        if (CurrentState == IBulletState.InUse)
        {
            transform.position += direction * force;
        }
    }

    public virtual void DestroyMe()
    {
        CurrentState = IBulletState.Destroying;
        InvockOnDestroy();
        DestroyVisualEffect();
    }

    public virtual void DestroyVisualEffect()
    {
        CurrentState = IBulletState.InPool;
    }

    #endregion

    #region Collision

    private void OnCollisionEnter(Collision collision)
    {
        OnCollisionDefaultBehaviour(collision);
    }

    private void OnCollisionDefaultBehaviour(Collision collision)
    {
        IEnemy enemyHit;

        if (CurrentState == IBulletState.InUse)
        {
            enemyHit = collision.gameObject.GetComponent<IEnemy>();
            if (enemyHit != null)
            {
                if (OnEnemyHit != null)
                {
                    InvockOnEnemyHit(enemyHit);
                }
            }
            DestroyMe();
        }
    }

    #endregion
}
