using UnityEngine;
using System.Collections;

public class DestroyOnExit : MonoBehaviour
{

    private void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject);
    }
}
