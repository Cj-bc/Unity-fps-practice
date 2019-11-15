using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float speed = 20.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 20.0f;

    private CharacterController controller;
    private Vector3 velocity, forward, right;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isGrounded) {
            forward = transform.transform.forward * Input.GetAxis("Vertical");
            right = transform.transform.right * Input.GetAxis("Horizontal");
            velocity = transform.TransformVector(forward + right) * speed;
            if (Input.GetButton("Jump"))
                velocity.y = jumpSpeed;
        }
        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
