﻿using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour
{
    


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.GetComponent<IBullet>().DestroyBehaviour();
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.GetComponent<IEnemy>().DestroyMe();
        }
    }


}
