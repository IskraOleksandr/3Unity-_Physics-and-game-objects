using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[AddComponentMenu("Control Script / Mouse Look")]
public class MouseLook : MonoBehaviour
{

    [SerializeField]
    private float hSensitivity = 9.8F;
    
    [SerializeField]
    private float vSensitivity = 9.8F;
    
    [SerializeField]
    private float minV_angle = -45.0F;
        
    [SerializeField]
    private float maxV_angle = 45.0F;
    
        
    private float rotationX = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody body = GetComponent<Rigidbody>();
        body.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        rotationX -= Input.GetAxis("Mouse Y") * vSensitivity;
        rotationX = Mathf.Clamp(rotationX, minV_angle, maxV_angle);
        
        float delta = Input.GetAxis("Mouse X") * hSensitivity;
        float rotationY = transform.localEulerAngles.y + delta;
        
        transform.localEulerAngles =  new Vector3(rotationX, rotationY, 0);
    }
}
