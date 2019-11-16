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
    private PlayerStatus status;
    private Vector3 velocity, forward, right;
    private float prev_up = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        status = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left shift")) // replace this by adding new virtual axis
            status.crouch = true;
        else
            status.crouch = false;

        if (controller.isGrounded)
            status.speed = baseSpeed;
        else
            status.speed = onAirMovementSpeed;

        forward = transform.transform.forward * Input.GetAxis("Vertical");  // W S
        right = transform.transform.right * Input.GetAxis("Horizontal");  // A D
        prev_up = velocity.y;
        velocity = transform.TransformVector(forward + right) * status.speed;
        velocity.y = prev_up;

        if (controller.isGrounded&&Input.GetButton("Jump"))
            velocity.y = jumpSpeed;

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
