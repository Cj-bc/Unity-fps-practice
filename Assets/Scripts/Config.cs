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
    public Dictionary<UsedKeysList, string> defaultConfig;

    // I want to change this phase to load config from somewhere, like yaml
    void Awake() {
        defaultConfig.Add(UsedKeysList.Crouch, "left shift" );
        defaultConfig.Add(UsedKeysList.Jump  , "Jump"       );
        defaultConfig.Add(UsedKeysList.Right , "Horizontal" );
        defaultConfig.Add(UsedKeysList.Foward, "Vertical"   );
        defaultConfig.Add(UsedKeysList.Fire  , "Fire1"      );
        defaultConfig.Add(UsedKeysList.Reload, "r"          );
    }
}
