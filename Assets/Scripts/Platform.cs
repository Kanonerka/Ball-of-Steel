using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    public float delay;
    public GameObject platform;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            StartCoroutine("Disappear");
        }
    }

    IEnumerator Disappear()
    {
        yield return new WaitForSeconds(delay);
        platform.SetActive(false);
        yield return new WaitForSeconds(delay * 2f);
        platform.SetActive(true);
    }
}
