using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Types;

public class CameraCtrl : MonoBehaviour
{

    public  CameraView mode;

    private GameObject player;
    private Config config;

    private CameraView prev_camMode;
    private Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        config = FindObjectOfType(typeof(Config)) as Config;
        mode = config.cameraConfig.mode;
        prev_camMode = config.cameraConfig.mode;
    }

    // Update is called once per frame
    void Update()
    {
        if (prev_camMode != mode) {
            switchCamera(mode);
            prev_camMode = mode;
        }

        // TODO: Change angle here
        transform.SetPositionAndRotation(player.transform.position + offset, Quaternion.identity);
    }


    private void switchCamera(CameraView m) {
        switch(m) {
            case CameraView.FPV:
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
