using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject platform;
    public Transform PressedPos;
    private Vector3 RegularPos;
    public float Smooth;
    private bool Press;

    void Start()
    {
        RegularPos = transform.position;
    }

    void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Player"))
        {
            Press = true;
            platform.SetActive(true);
        }
    }
    
    void Update()
    {
        if (Press)
        {
            // Движение кнопки
            transform.position = Vector3.Lerp(transform.position, PressedPos.position, Smooth * Time.deltaTime);
            StartCoroutine("Back");
        }
    }

    // Реактивация. Возврат кнопки в исходное положение.
    IEnumerator Back()
    {
        yield return new WaitForSeconds(3.0f);
        Press = false;
        transform.position = RegularPos;
    }
}
