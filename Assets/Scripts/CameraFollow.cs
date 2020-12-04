using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float camSpeed = 130.0f;
    public float sensitivityX;
    public float sensitivityY;
    private float rotX = 0.0f;
    private float rotY = 0.0f;

    void Start()
    {
        Vector3 rotation = transform.localRotation.eulerAngles;
        rotX = rotation.x;
        rotY = rotation.y;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        rotX += Input.GetAxis("Mouse X") * sensitivityX;
        rotY -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotY = Mathf.Clamp(rotY, -60, 40); // Ограничение угла наклона камеры
        
        transform.rotation = Quaternion.Euler(rotY, rotX, 0.0f); // Вращение камеры

        // Управление поворотом шара по оси Х
        target.rotation = Quaternion.Euler(0, rotX, 0);
    }

    void LateUpdate ()
    {
        CameraUpdater();
    }

    void CameraUpdater()
    {
        // Движение камеры за шаром
        transform.position = Vector3.MoveTowards(transform.position, target.position, camSpeed * Time.deltaTime);
    }
}
