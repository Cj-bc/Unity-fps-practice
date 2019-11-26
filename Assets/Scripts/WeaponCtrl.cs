using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class WeaponCtrl : MonoBehaviour
{
    const int MAX_Ammo = 10;
    public int damage = 0;
    public float fireRate = 10.0f;
    public int ammos = MAX_Ammo;
    public GunType guntype;
    public Vector3 offset;
    public Vector3 adsOffset;

    // Things to wanna add in the future
    // public Attachment scope;
    // public float recoil;

    private PlayerStatus status;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindObjectOfType<PlayerStatus>();
        transform.localPosition = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if(status.isADS && transform.localPosition != adsOffset)
          transform.localPosition = Vector3.Lerp(transform.localPosition, adsOffset, Time.deltaTime);
        else if(!status.isADS && transform.localPosition != offset)
          transform.localPosition = Vector3.Lerp(transform.localPosition, offset, Time.deltaTime);
    }


    private void ads() {
    }
}
