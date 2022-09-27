using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Preset Fields")] public PlayerControl pControl;
    public ParticleSystem walkParticle;
    public Animator animator;

    [Header("Settings")] public float turnSpeed = 3f;

    public bool rangeAttack;
    private bool isWalking;

    private void Awake()
    {
        pControl.animator = this;
    }

    private void Update()
    {
        animator.SetBool("walking", isWalking);
        animator.SetBool("landed", pControl.landed);
        animator.SetBool("rangeAttack", rangeAttack);

        transform.rotation = Quaternion.Lerp(transform.rotation, pControl.rotation, Time.deltaTime * turnSpeed);

        if (pControl.landed && pControl.moving)
        {
            if (!isWalking)
            {
                isWalking = true;
                walkParticle.time = 0f;
                walkParticle.Play();
            }
        }
        else
        {
            if (isWalking)
            {
                isWalking = false;
                walkParticle.Stop();
            }
        }
    }

    public void MeleeAttack()
    {
        animator.SetTrigger("meleeAttack");
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }
}