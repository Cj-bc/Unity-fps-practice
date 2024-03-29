using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private PlayerCtrl playerCtrl;
    private Animator animator;
    private PlayerStatus status;

    // Start is called before the first frame update
    void Start()
    {
        playerCtrl = GetComponent<PlayerCtrl>();
        animator = GetComponent<Animator>();
        status = GetComponent<PlayerStatus>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("speed", status.velocity.magnitude);
        animator.SetBool("crouch", status.crouch);
        animator.SetBool("ads", status.isADS);
    }
}
