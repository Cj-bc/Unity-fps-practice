using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Types;

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
    public CameraConfig cameraConfig;


    // I want to change this phase to load config from somewhere, like yaml
    void Awake() {
        setDefault();
    }

    void setDefault() {
        this.keyConfig.Add(UsedKeysList.Crouch, KeyCode.LeftShift );
        this.keyConfig.Add(UsedKeysList.Jump  , KeyCode.Space );
        this.keyConfig.Add(UsedKeysList.Fire  , KeyCode.Mouse1 );
        this.keyConfig.Add(UsedKeysList.Reload, KeyCode.R );
        this.cameraConfig = CameraConfig.defaultConfig();
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

    public static CameraConfig defaultConfig() {
        CameraConfig ret = new CameraConfig();
        ret.mode = CameraView.FPV;
        ret.tppOffset = new Vector3(-4, 15, -15);
        return ret;
    }
}
