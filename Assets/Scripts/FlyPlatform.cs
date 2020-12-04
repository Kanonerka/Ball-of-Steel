using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyPlatform : MonoBehaviour
{
    private float flyingSpeed = 0;
    private bool isFlying;
    public float timer;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            isFlying = true;
            Destroy(gameObject, timer);
        }
    }

    void FixedUpdate()
    {
        if (isFlying)
        {
            flyingSpeed += Time.deltaTime / 30;
            transform.position = new Vector3(transform.position.x, transform.position.y + flyingSpeed, transform.position.z);
        }
    }
}
