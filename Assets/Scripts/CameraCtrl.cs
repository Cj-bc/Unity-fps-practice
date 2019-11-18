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

    private CameraView prev_camMode;
    private Vector3 offset = new Vector3(0.0f, 12.0f, 1.03f);
    private Vector3 crouchOffset = new Vector3(0, -5, 0);
    private float crouchTime;
    const float crouchTimeLimit = 1;


    void Start() {
        player = GameObject.FindWithTag("Player");
        plStatus = player.GetComponent<PlayerStatus>();
        config = FindObjectOfType(typeof(Config)) as Config;
        mode = config.cameraConfig.mode;
        prev_camMode = config.cameraConfig.mode;

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
