using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class Config : MonoBehaviour
{
    public enum UsedKeysList {
          Crouch
        , Jump
        , Right
        , Foward
        , Fire
        , ADS
        , Reload
    }

    public Dictionary<UsedKeysList, KeyCode> keyConfig = new Dictionary<UsedKeysList, KeyCode>();
    public Sensitivity sensitivity;
    public CameraConfig cameraConfig;

    private bool _isSet = false; // True if custom configuration is given;


    // I want to change this phase to load config from somewhere, like yaml
    void Awake() {
        if (!_isSet)
            setDefault();
    }

    void setDefault() {
        this.keyConfig.Add(UsedKeysList.Crouch, KeyCode.LeftShift );
        this.keyConfig.Add(UsedKeysList.Jump  , KeyCode.Space );
        this.keyConfig.Add(UsedKeysList.Fire  , KeyCode.Mouse1 );
        this.keyConfig.Add(UsedKeysList.Reload, KeyCode.R );
        this.cameraConfig = CameraConfig.defaultConfig();
        this.sensitivity = new Sensitivity(10, 4);
    }

    static Config defaultConfig() {
        Config ret = new Config();
        ret.setDefault();
        return ret;
    }
}


public class CameraConfig {
    public CameraView mode;
    public Vector3 tppOffset;
    public float fov;
    public bool flipY;

    public static CameraConfig defaultConfig() {
        CameraConfig ret = new CameraConfig();
        ret.mode = CameraView.FPP;
        ret.tppOffset = new Vector3(-4, 15, -15);
        ret.fov = 60.0f;
        ret.flipY = false;
        return ret;
    }
}
