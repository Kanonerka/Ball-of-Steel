using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateControl : MonoBehaviour
{
    public Transform Wing;
    public Transform Open;
    public float Smooth;
    private bool Opening;
    
    void OnTriggerEnter(Collider Object)
    {
        if (Object.CompareTag("Item"))
        {
            Destroy(Object.gameObject, 0.3f);
            Opening = true;
        }
    }
    
    void Update()
    {
        if (Opening)
        {
            Wing.position = Vector3.Lerp(Wing.position, Open.position, Smooth * Time.deltaTime);
        }
    }
}
