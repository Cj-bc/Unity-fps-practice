using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Types;

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


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        plStatus = player.GetComponent<PlayerStatus>();
        config = FindObjectOfType(typeof(Config)) as Config;
        mode = config.cameraConfig.mode;
        prev_camMode = config.cameraConfig.mode;

        crouchTime = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (prev_camMode != mode) {
            switchCamera(mode);
            prev_camMode = mode;
        }

        if (plStatus.crouch)
            crouchTime = Mathf.Min(crouchTime+0.05f, crouchTimeLimit);
        else
            crouchTime = Mathf.Max(crouchTime-0.05f, 0.0f);

        transform.SetPositionAndRotation(player.transform.position + offset + (crouchOffset * crouchTime)
                                        , player.transform.rotation);


        // TODO: Change angle here
        // What I should do here are:
        //   - Change position to player's position + offset
        //   - rotate camera if player rotate.
        //
        // TPP support is not so easy(4 me), because I should use Quaternion or matrix
        // And Important thing here is: are there any reason to add TPP?
        // (Actually I don't play TPS lol)
        // v ----- v
        // Vector2 cam_pos = new Vector2(offset.x, offset.z);
        // Vector3 n_pos = offset * Mathf.Cos(-player.transform.rotation.y);
        // transform.SetPositionAndRotation(player.transform.position + n_pos, player.transform.rotation);
        // ^ ----- ^
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
