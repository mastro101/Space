using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour
{
    


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            other.GetComponent<BulletStandard>().DestroyMe();
        }
    }
}
