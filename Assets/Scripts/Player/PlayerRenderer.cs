using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour {
    [Header("Preset Fields")]
    public PlayerControl playerControl;
    public ParticleSystem walkParticle;
    public Animator animator;

    [Header("Settings")]
    public float turnSpeed = 3f;

    public bool rangeAttack;
    private bool isWalking;
    private bool isRolling;

    private void Awake() {
        playerControl.playerRenderer = this;
    }

    private void Update() {
        animator.SetBool("walking", isWalking);
        animator.SetBool("landed", playerControl.landed);
        animator.SetBool("rangeAttack", rangeAttack);

        if(playerControl.canMove)
            transform.rotation = Quaternion.Lerp(transform.rotation, playerControl.rotation, Time.deltaTime * turnSpeed);

        if(playerControl.landed && playerControl.moving) {
            if (!isWalking /*|| isRolling */) {
                isWalking = true;
                walkParticle.time = 0f;
                walkParticle.Play();
            }
        }
        else {
            if (isWalking) {
                isWalking = false;
                walkParticle.Stop();
            }
        }
    }

    public void MeleeAttack() {
        animator.SetTrigger("meleeAttack");
    }

    public void Jump() {
        animator.SetTrigger("jump");
    }

    public void Roll() {
        animator.SetTrigger("roll");
    }
}
