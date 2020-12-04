using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    public float force;
    public float jumpForce;
    public Transform controller;
    public LayerMask GroundLayers;
    private SphereCollider col;
    public float maxSpeed;

    void Start()
    {
        col = GetComponent<SphereCollider>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
            rb.AddForce(controller.forward * force * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.S))
            rb.AddForce(controller.forward * -force * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.D))
            rb.AddForce(controller.right * force * Time.fixedDeltaTime);
        if (Input.GetKey(KeyCode.A))
            rb.AddForce(controller.right * -force * Time.fixedDeltaTime);

        if (IsGrounded() && Input.GetKey(KeyCode.Space)) // Расчет прыжка
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        if (rb.velocity.magnitude > maxSpeed) // Ограничение скорости
            rb.velocity = rb.velocity.normalized * maxSpeed;
        
    }

    private bool IsGrounded()
    {
        // Проверка на приземление
        return Physics.CheckCapsule(col.bounds.center, new Vector3(col.bounds.center.x, col.bounds.center.y-0.15f, col.bounds.center.z), col.radius * 0.9f, GroundLayers);
    }
}
