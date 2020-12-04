using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform Place;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Player"))
        {
            rb = Object.GetComponent<Rigidbody>();
            StartCoroutine("Teleportation");
        }
    }

    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds(0.4f);
        rb.MovePosition(Place.position);
    }
}
