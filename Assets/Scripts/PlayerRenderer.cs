using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour {
    [Header("Preset Fields")]
    public PlayerControl pcon;
    //public ParticleSystem walkParticle;
    public Animator animator;

    [Header("Settings")]
    public float turnSpeed = 3f;

    public bool rangeAttack;
    private bool isWalking;

    private void Awake() {
        pcon.animator = this;
    }

    private void Update() {
        animator.SetBool("walking", isWalking);
        animator.SetBool("landed", pcon.landed);
        animator.SetBool("rangeAttack", rangeAttack);

        transform.rotation = Quaternion.Lerp(transform.rotation, pcon.rotation, Time.deltaTime * turnSpeed);

        if(pcon.landed && pcon.moving) {
            if (!isWalking) {
                isWalking = true;
               // walkParticle.time = 0f;
                //walkParticle.Play();
            }
        }
        else {
            if (isWalking) {
                isWalking = false;
               // walkParticle.Stop();
            }
        }
    }

    public void MeleeAttack() {
        animator.SetTrigger("meleeAttack");
    }

    public void Jump() {
        animator.SetTrigger("jump");
    }
}
