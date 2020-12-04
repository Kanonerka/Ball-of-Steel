using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleRed : MonoBehaviour
{
    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    private Vector3 Respawn;

    void Start()
    {
        Respawn = transform.position; // Место возрождения
    }

    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Deadly"))
        {
            StartCoroutine("Resp");
        }
    }

    private void Update()
    {
        lastFrameVelocity = rb.velocity;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Bounce(collision.contacts[0].normal);
    }

    private void Bounce(Vector3 collisionNormal)
    {
        // Расчет отскока
        var speed = lastFrameVelocity.magnitude;
        var direction = Vector3.Reflect(lastFrameVelocity.normalized, collisionNormal);
        
        rb.velocity = direction * Mathf.Max(speed, 1.0f);
    }

    IEnumerator Resp()
    {
        // Перемещение в исходное положение, остановка движения.
        yield return new WaitForSeconds(1.5f);
        transform.position = Respawn;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
