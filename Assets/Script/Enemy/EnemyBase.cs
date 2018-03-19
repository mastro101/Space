using UnityEngine;
using System.Collections;
using System;

public abstract class EnemyBase : MonoBehaviour, IEnemy {

    protected IEnemyState _currentState = IEnemyState.InPool;

    public bool IsAlive = true;
    public int ScoreValue;
    public float MovementSpeed;
    public float leftLimit, rightLimit;
    public bool goLeft, goRight;
    public int Life;

    int _life;
    bool _goLeft, _goRight;

    public IEnemyState CurrentState
    {
        get { return _currentState; }
        set { _currentState = value; }
    }

    public event IEnemyEvents.EnemyEvent OnSpawn;
    public event IEnemyEvents.EnemyEvent OnDestroy;

    public string ID
    {
        get { return getID(); }
    }

    protected abstract string getID();

    public int Score
    {
        get { return ScoreValue; }
    }
    
    public float LeftLimit
    {
        get { return leftLimit; }
    }

    public float RightLimit
    {
        get { return rightLimit; }
    }

    #region Events

    protected void InvockOnSpawn()
    {
        if (OnSpawn != null)
            OnSpawn(this);
    }

    protected void InvockOnDestroy()
    {
        if (OnDestroy != null)
            OnDestroy(this);
    }

    #endregion

    #region InGame

    public virtual void TakeDamage(int damage)
    {
        Life -= damage;
        if (Life <= 0)
        {
            IsAlive = false;
            DestroyMe();
        }
    }
    
    public virtual void Spawn()
    {
        StartStatistic();
        CurrentState = IEnemyState.InUse;
        InvockOnSpawn();

    }

    private void StartStatistic()
    {
        _life = Life;
        _goRight = goRight;
        _goLeft = goLeft;
    }

    public virtual void DestroyMe()
    {
        CurrentState = IEnemyState.Destroying;
        InvockOnDestroy();
        DestroyVisualEffect();
        TakeStartStatistic();
    }

    private void TakeStartStatistic()
    {
        Life = _life;
        goLeft = _goLeft;
        goRight = _goRight;
    }

    public virtual void DestroyVisualEffect()
    {
        CurrentState = IEnemyState.InPool;
    }

    #endregion

    #region Collision

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

    #endregion
}
