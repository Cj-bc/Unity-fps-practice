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
        keyConfig.Add(UsedKeysList.Crouch, KeyCode.LeftShift );
        keyConfig.Add(UsedKeysList.Jump  , KeyCode.Space );
        keyConfig.Add(UsedKeysList.Fire  , KeyCode.Mouse1 );
        keyConfig.Add(UsedKeysList.Reload, KeyCode.R );
        cameraConfig = CameraConfig.defaultConfig();
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
