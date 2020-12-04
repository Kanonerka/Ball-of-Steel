using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour
{
    void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Player"))
        {
            Destroy(gameObject, 0.2f);
        }
    }
}
