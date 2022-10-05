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
    [Header("Debug")] public bool crouching;

    [SerializeField] private bool isWalking;

    private void Awake()
    {
        pControl.animator = this;
    }

    private void Update()
    {
        animator.SetBool("walking", isWalking);
        animator.SetBool("landed", pControl.landed);
        animator.SetBool("crouching", crouching);

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

    public void RangeAttack()
    {
        animator.SetTrigger("rangeAttack");
    }

    public void MeleeAttack()
    {
        animator.SetTrigger("meleeAttack");
    }

    public void SkillAttack()
    {
        animator.SetTrigger("skillAttack");
    }

    public void Jump()
    {
        animator.SetTrigger("jump");
    }

    //특정 이름을 가진 애니메이션 재생중인지 확인
    public bool IsPlaying(string name)
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.normalizedTime > 0 && stateInfo.IsName(name);
    }

    public bool IsInTransition(string name)
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.normalizedTime > 0 && stateInfo.IsName(name) && animator.IsInTransition(0);
    }

    public bool IsAnyPlaying(params string[] names)
    {
        var stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        bool any = false;
        for (int i = 0; i < names.Length && !any; i++) any = stateInfo.IsName(names[i]);
        return stateInfo.normalizedTime > 0 && any;
    }
}