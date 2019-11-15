using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float baseSpeed = 20.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 20.0f;
    public float onAirMovementSpeed = 10.0f;

    private CharacterController controller;
    private Vector3 velocity, forward, right;
    private float prev_up = 0.0f;
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded)
            speed = baseSpeed;
        else
            speed = onAirMovementSpeed;

        forward = transform.transform.forward * Input.GetAxis("Vertical");  // W S
        right = transform.transform.right * Input.GetAxis("Horizontal");  // A D
        prev_up = velocity.y;
        velocity = transform.TransformVector(forward + right) * speed;
        velocity.y = prev_up;

        if (controller.isGrounded&&Input.GetButton("Jump"))
            velocity.y = jumpSpeed;

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
