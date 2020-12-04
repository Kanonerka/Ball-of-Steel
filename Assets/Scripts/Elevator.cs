using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    private Rigidbody rb;
    public float liftingSpeed;

    private void OnTriggerStay(Collider Object)
    {
        if (Object.CompareTag("Player"))
        {
            rb = Object.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.up * liftingSpeed * Time.deltaTime);
        }
    }
}
