using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Types;

// Camera should be a children of player.
public class CameraCtrl : MonoBehaviour
{

    public  CameraView mode;

    private GameObject player;
    private Config config;
    private PlayerStatus plStatus;
    private Camera cameraComponent;

    private CameraView prev_camMode;
    private Vector3 offset = new Vector3(0.0f, 12.0f, 1.03f);
    private Vector3 crouchOffset = new Vector3(0, -5, 0);
    private float crouchTime = 0.0f;
    const float crouchTimeLimit = 1;
    const float MAX_ANGLE = 40.0f;
    const float MIN_ANGLE = -40.0f;


    void Start() {
        // Get objects/components
        player = GameObject.FindWithTag("Player");
        plStatus = player.GetComponent<PlayerStatus>();
        cameraComponent = GetComponent<Camera>();
        config = FindObjectOfType(typeof(Config)) as Config;

        // Initialize CameraCtrl
        mode = config.cameraConfig.mode;
        prev_camMode = config.cameraConfig.mode;

        // Initialize Camera
        cameraComponent.fieldOfView = config.cameraConfig.fov;

        crouchTime = 0.0f;
    }

    void Update() {
        if (prev_camMode != mode) {
            switchCamera(mode);
            prev_camMode = mode;
        }

        crouchTime = plStatus.crouch ? Mathf.Min(crouchTime+0.05f, crouchTimeLimit)
                                     : Mathf.Max(crouchTime-0.05f, 0.0f);
        transform.localPosition = offset + (crouchOffset * crouchTime);

        float y_flip = config.cameraConfig.flipY ? -1 : 1;
        // transform.localEulerAngles.{x,y,z} seems to be set between 0 to 360 by Unity, even if we set them to negative value.
        // So I should convert them into -180~180 range so that it's easier to use Mathf.Clamp.
        float xAngleAllowingNegative = 180 < transform.localEulerAngles.x ? -(360 - transform.localEulerAngles.x)
                                                                          : transform.localEulerAngles.x;
        float rot = Mathf.Clamp(xAngleAllowingNegative - y_flip * (Input.GetAxis("Mouse Y") * config.sensitivity.Y)
                         , MIN_ANGLE
                         , MAX_ANGLE
                         );
        transform.localEulerAngles = new Vector3(rot, 0, 0);
    }


    private void switchCamera(CameraView m) {
        switch(m) {
            case CameraView.FPP:
                offset = new Vector3(0.0f, 12.0f, 1.03f);
                break;
            case CameraView.TPP:
                offset = config.cameraConfig.tppOffset;
                break;
            case CameraView.FreeCam:
                // This is not implemented yet!!!
                // TODO: implement this
                // I don't know how to move camera. Which key to use?
                offset = new Vector3(10, 10, 10);
                break;
        }
    }
}
