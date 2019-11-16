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
    public Dictionary<UsedKeysList, KeyCode> keyConfig;

    // I want to change this phase to load config from somewhere, like yaml
    void Awake() {
        keyConfig.Add(UsedKeysList.Crouch, KeyCode.LeftShift );
        keyConfig.Add(UsedKeysList.Jump  , KeyCode.Space );
        keyConfig.Add(UsedKeysList.Fire  , KeyCode.Mouse1 );
        keyConfig.Add(UsedKeysList.Reload, KeyCode.R );
    }
}
