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
    private Config config;
    private Dictionary<Config.UsedKeysList, KeyCode> keyConf;
    private Vector3 velocity, forward, right;
    private float prev_up = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        status = GetComponent<PlayerStatus>();
        config = FindObjectOfType(typeof(Config)) as Config;
        keyConf = config.keyConfig;
    }

    // Update is called once per frame
    void Update()
    {
        status.crouch  = Input.GetKey(keyConf[Config.UsedKeysList.Crouch]);
        status.speed   = controller.isGrounded ? baseSpeed : onAirMovementSpeed;

        forward = transform.transform.forward * Input.GetAxis("Vertical");  // W S
        right = transform.transform.right * Input.GetAxis("Horizontal");  // A D
        prev_up = velocity.y;
        velocity = transform.TransformVector(forward + right) * status.speed;
        velocity.y = prev_up;

        if (controller.isGrounded&&Input.GetKey(keyConf[Config.UsedKeysList.Jump]))
            velocity.y = jumpSpeed;

        velocity.y -= gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
