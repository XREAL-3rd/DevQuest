using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRenderer : MonoBehaviour
{
    [Header("Preset Fields")]
    public PlayerControl pcon;

    public ParticleSystem walkParticle;

    public Animator animator;

    [Header("Settings")]
    public float turnSpeed = 3f;

    public bool rangeAttack;

    private bool isWalking;

    private bool isSitting;

    private float lastRangeAttack = -100.0f;

    private Vector3 lastRangeAttackDir;

    private void Awake()
    {
        pcon.animator = this;
    }

    private void Update()
    {
        animator.SetBool("walking", isWalking);
        animator.SetBool("sitting", isSitting);
        animator.SetBool("landed", pcon.landed);

        int currentState = animator.GetCurrentAnimatorStateInfo(0).fullPathHash;
        int archerAim = Animator.StringToHash("Base Layer.ArcherAim");
        int archerDraw = Animator.StringToHash("Base Layer.ArcherDraw");
        if (currentState == archerAim || currentState == archerDraw){ 
            transform.rotation = Quaternion.LookRotation(lastRangeAttackDir) * Quaternion.Euler(0, 90, 0);
        }
        else
        {
            transform.rotation =
                Quaternion
                    .Lerp(transform.rotation,
                    pcon.rotation,
                    Time.deltaTime * turnSpeed);
        }
        animator.SetBool("rangeAttack", rangeAttack);
        rangeAttack = false;

        if (pcon.landed && pcon.moving)
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

        if (pcon.sitting)
        {
            isSitting = true;
        }
        else
        {
            isSitting = false;
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

    public void RangeAttack(Vector3 dir)
    {
        rangeAttack = true;
        lastRangeAttack = Time.time;
        lastRangeAttackDir = dir;
    }
}
