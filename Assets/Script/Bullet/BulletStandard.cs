using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStandard : BulletBase {


    protected override string getID()
    {
        return "BulletStandard";
    }

    #region Visual effect

    public ParticleSystem particleSystem;

    public override void DestroyVisualEffect()
    {
        particleSystem.Play();
        
    }

    #endregion


}
