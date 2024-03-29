using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class PlayerCtrl : MonoBehaviour
{
    public float baseSpeed = 20.0f;
    public float jumpSpeed = 20.0f;
    public float gravity = 30.0f;
    public float onAirMovementSpeed = 10.0f;

    private CharacterController controller;
    private PlayerStatus status;
    private Config config;
    private Dictionary<Config.UsedKeysList, KeyCode> keyConf;
    private Vector3 velocity;
    private float prev_up = 0.0f;
    private float speed;

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
        // ========== Moving section
        status.crouch  = Input.GetKey(keyConf[Config.UsedKeysList.Crouch]);
        speed   = controller.isGrounded ? baseSpeed : onAirMovementSpeed;

        transform.Rotate(0, Input.GetAxis("Mouse X") * config.sensitivity.X, 0);

        velocity = transform.TransformVector(new Vector3( Input.GetAxis("Horizontal") * speed
                                                        , velocity.y
                                                        , Input.GetAxis("Vertical")   * speed)
                                            );

        if (controller.isGrounded&&Input.GetKey(keyConf[Config.UsedKeysList.Jump]))
            velocity.y = jumpSpeed;

        velocity.y -= gravity * Time.deltaTime;

        status.velocity = new Vector3(velocity.x, 0, velocity.z);

        controller.Move(velocity * Time.deltaTime);


        // ========== Firing section
        ads(config.adsmode);

        if (Input.GetKey(keyConf[Config.UsedKeysList.Fire]))
            if (!status.isFiring) status.isFiring = true;

        if (Input.GetKeyUp(keyConf[Config.UsedKeysList.Fire]) && status.isFiring)
            status.isFiring = false;
    }

    private void ads(KeyPushMode m) {
        switch(m) {
          case KeyPushMode.Hold:
              if (Input.GetKey(keyConf[Config.UsedKeysList.ADS]) && !status.isADS)
                  status.isADS = true;
              else if (Input.GetKeyUp(keyConf[Config.UsedKeysList.ADS]) && status.isADS)
                  status.isADS = false;
              break;
          case KeyPushMode.Toggle:
              if (Input.GetKey(keyConf[Config.UsedKeysList.ADS]))
                  status.isADS = !status.isADS;
              break;
        }
    }
}
