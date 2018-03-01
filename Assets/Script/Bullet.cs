using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public State CurrentState = State.InPool;

    #region API

    public void Shoot()
    {
        CurrentState = State.InUse;
    }
    public void Destroy()
    {
        CurrentState = State.InPool;
    }

    #endregion

    public enum State
    {
        InPool,
        InUse,

    }

}
