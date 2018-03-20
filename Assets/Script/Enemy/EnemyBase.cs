using UnityEngine;
using System.Collections;
using System;

public abstract class EnemyBase : MonoBehaviour, IEnemy {

    protected IEnemyState _currentState = IEnemyState.InPool;

    public string IDEnemy;
    public int Life;
    public bool IsAlive = true;
    public float MovementSpeed;
    public Transform leftLimit, rightLimit;
    public bool goLeft, goRight;
    public int ScoreValue;

    public float ShootForce;
    public Transform ShootStartPosition;
    public GameObject CurrentBulletGOPrefab;

    BulletPoolManager bulletManager;
    string BulletID;

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
        get { return IDEnemy; }
    }

    public int Score
    {
        get { return ScoreValue; }
    }
    
    public Transform LeftLimit
    {
        get { return leftLimit; }
    }

    public Transform RightLimit
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

    public abstract void MovementBehaviour();

    public virtual void ShootBehaviour()
    {
        if (CurrentState == IEnemyState.InUse)
            GetBullet().Shoot(ShootStartPosition.forward, ShootForce);

    }

    public IBullet GetBullet()
    {
        IBullet bulletToShoot = bulletManager.GetBullet(BulletID);
        bulletToShoot.gameObject.transform.position = ShootStartPosition.position;
        bulletToShoot.OnDestroy += OnBulletDestroy;
        return bulletToShoot;
    }

    private void OnBulletDestroy(IBullet bullet)
    {
        
    }

    public void FixedUpdate()
    {
        MovementBehaviour();
        ShootBehaviour();
    }

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

    private void Start()
    {
        IBullet currentBullet = CurrentBulletGOPrefab.GetComponent<IBullet>();
        if (currentBullet == null)
            return;
        BulletID = currentBullet.ID;
        bulletManager = FindObjectOfType<BulletPoolManager>(); 
    }

    private void StartStatistic()
    {
       
        IsAlive = true;
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
