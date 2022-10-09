using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour {
    [Header("Preset Fields")]
    public PlayerControl pcon;
    public ParticleSystem walkParticle;
    public Animator animator;

    [Header("Settings")]
    public float turnSpeed = 3f;

    private bool isWalking = false, isGrounded = true, isRangeAttacking = false, isRunning = false, isCrouching = false;

    private void Awake() {}

    private void Update() {}

    public void toggleWalk(bool input){
        if(isWalking != input){
            isWalking = input;
            animator.SetBool("walking", isWalking);
            if(isWalking){
                walkParticle.time = 0f;
                walkParticle.Play();
            }
            else{ walkParticle.Stop(); }
        }
    }

    public void toggleRun(bool input){
        if (isRunning != input){
            isRunning = input;
            if(isRunning){Debug.Log("animation : running");}
            else {Debug.Log("animation : stopped running");}
        }
    }

    public void toggleCrouch(bool input){
        if(isCrouching != input){
            isCrouching = input;
            Debug.Log("toggle Crouch");
        }
    }

    public void toggleGrounded(bool input){
        if(isGrounded != input){
            isGrounded = input;
            animator.SetBool("landed", isGrounded);
        }
    }

    public void MeleeAttack() {
        animator.SetTrigger("meleeAttack");
    }

    public void Jump() {
        animator.SetTrigger("jump");
    }

    public void Shoot() {
        animator.SetTrigger("rangeAttack");
    }
}
