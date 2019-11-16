using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public Dictionary<UsedKeysList, KeyCode> defaultConfig;

    // I want to change this phase to load config from somewhere, like yaml
    void Awake() {
        defaultConfig.Add(UsedKeysList.Crouch, KeyCode.LeftShift );
        defaultConfig.Add(UsedKeysList.Jump  , KeyCode.Space );
        defaultConfig.Add(UsedKeysList.Fire  , KeyCode.Mouse1 );
        defaultConfig.Add(UsedKeysList.Reload, KeyCode.R );
    }
}
