using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CargoTeleport : MonoBehaviour
{
    public Transform Place;
    private Rigidbody rb;

    private void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Item"))
        {
            rb = Object.GetComponent<Rigidbody>();
            StartCoroutine("Teleportation");
        }
    }

    IEnumerator Teleportation()
    {
        yield return new WaitForSeconds(0.3f);
        rb.MovePosition(Place.position);
    }
}
