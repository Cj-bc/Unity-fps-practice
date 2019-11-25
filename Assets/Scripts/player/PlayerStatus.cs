using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    const int MAX_health = 100;
    public bool crouch = false;
    public bool isADS = false;
    public bool isFiring = false;
    public Vector3 velocity = new Vector3();
    public int health = MAX_health;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
