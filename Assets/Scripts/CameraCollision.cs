using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollision : MonoBehaviour
{
    public float minDistance = 1.0f;
    public float maxDistance = 7.0f;
    public float smooth = 2.0f;
    private Vector3 camDir;
    public float distance;

    void Awake()
    {
        camDir = transform.localPosition.normalized;
        distance = transform.localPosition.magnitude;
    }
    
    void Update()
    {
        Vector3 desiredCamPos = transform.parent.TransformPoint(camDir * maxDistance);
        RaycastHit hit;

        if (Physics.Linecast (transform.parent.position, desiredCamPos, out hit))
        {
            distance = Mathf.Clamp(hit.distance * 0.7f, minDistance, maxDistance);
        }
        else
        {
            distance = maxDistance;
        }
        transform.localPosition = Vector3.Lerp(transform.localPosition, camDir * distance, Time.deltaTime * smooth);
    }
}
