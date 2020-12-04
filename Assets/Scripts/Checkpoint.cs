using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameObject Respawn;

    void Start()
    {
        Respawn = GameObject.FindGameObjectWithTag("Respawn");
    }
    
    private void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Player"))
        {
            Respawn.transform.position = transform.position;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
