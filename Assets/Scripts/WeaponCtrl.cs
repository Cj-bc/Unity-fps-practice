using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Types;

public class WeaponCtrl : MonoBehaviour
{
    const int MAX_Ammo = 10;
    public int damage = 0;
    public float fireInterbal = 0.1f; // sec
    public int ammos = MAX_Ammo;
    public GunType guntype;
    public Vector3 offset;
    public GameObject bullet;

    // Things to wanna add in the future
    // public Attachment scope;
    // public float recoil;

    private PlayerStatus status;
    private float fireIntervalRemain;
    private bool fired;

    // Start is called before the first frame update
    void Start()
    {
        status = GameObject.FindObjectOfType<PlayerStatus>();
        transform.localPosition = offset;
    }

    // Update is called once per frame
    void Update()
    {
        if (status.isFiring)
          fire(guntype, ammos);
        else
          fireIntervalRemain = 0;
    }

    void fire(GunType gt, int ammo) {
        if (ammo <= 0)
            // TODO: play sound if run out of ammo
            return;

        switch(gt) {
            case GunType.Semi:
                if(fired) return;

                Instantiate(bullet, transform.position, transform.rotation);
                fired = true;
                break;
            case GunType.Auto:
                if(0 <= fireIntervalRemain) {
                    fireIntervalRemain -= Time.deltaTime;
                    return;
                }

                Instantiate(bullet, transform.position, transform.rotation);
                fireIntervalRemain = fireInterbal;
                break;
        }



    }
}
