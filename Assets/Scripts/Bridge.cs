using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    void OnTriggerExit(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }
}
