using UnityEngine;
using System.Collections;
using System;

public abstract class BulletBase : MonoBehaviour, IBullet
{
    protected State _currentState = State.InPool;

    public State CurrentState
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

    protected void InvockOnEnemyHit()
    {
        if (OnEnemyHit != null)
            OnEnemyHit(this);
    }

    #endregion

    #region Shoot

    Vector3 direction;
    float force;

    public virtual void Shoot(Vector3 _direction, float _force)
    {
        CurrentState = State.InUse;
        if (OnShoot != null)
            OnShoot(this);
        direction = _direction;
        force = _force;
    }

    private void FixedUpdate()
    {
        OnFixedUpdate();
    }

    private void OnFixedUpdate()
    {
        if (CurrentState == State.InUse)
        {
            transform.position += direction * force;
        }
    }

    public virtual void DestroyMe()
    {
        CurrentState = State.Destroying;
        if (OnDestroy != null)
            OnDestroy(this);
        DestroyVisualEffect();
    }

    public virtual void DestroyVisualEffect()
    {
        CurrentState = State.InPool;
    }

    #endregion
}
