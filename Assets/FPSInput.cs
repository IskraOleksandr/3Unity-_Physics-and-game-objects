using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script / FPS Input")]
public class FPSInput : MonoBehaviour
{

    [SerializeField]
    private float speed = 15.0F;

    [SerializeField]
    private float gravity = -9.8F;

    private CharacterController _characterController;


    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        vector = transform.TransformDirection(vector);
        vector *= speed;

        Vector3.ClampMagnitude(vector, speed);
        vector.y = gravity;
        vector *= Time.deltaTime;

        //from local to global coord and move
        _characterController.Move(vector);
    }

}
