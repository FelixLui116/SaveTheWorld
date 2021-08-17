using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

     private void Awake() {
        // target = GameObject.Find("PlayerController").GetComponent<Transform>();
    }
    void Start()
    {
        
        target = GameObject.Find("Player").GetComponent<Transform>();
    }

    // void LateUpdate()
    // {
    //     transform.position = target.position + offset;
    // }

    private void FixedUpdate() {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position , desiredPosition , smoothSpeed);
            transform.position = smoothedPosition;
            transform.LookAt(target);
            
        }
 
    }
}
