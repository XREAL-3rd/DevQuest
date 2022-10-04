using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcAnim : MonoBehaviour
{
    Animator animator;
    OrcMove Orc;
    enum State { Idle, Walk, Run, Attack };
    State currState;
    bool invoked;
    public bool live = true;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Orc = GetComponent<OrcMove>();
        currState = State.Idle;
        changeIdle();
        invoked = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (live)
        {
            AnimationUpdate();
        }
    }

    void AnimationUpdate()
    {
        if(currState == State.Idle && !invoked)
        {
            //Must call Turn 180 deg
            Orc.changeState(0);
            Invoke("changeWalk", 2.0f);
            invoked = true;
        }else if(currState == State.Walk && !invoked)
        {
            Orc.changeState(1);
            Invoke("changeIdle", 4.0f);
            invoked = true;
        }
    }

    void changeWalk()
    {
        animator.SetInteger("State", 1);
        currState = State.Walk;
        invoked = false;
        //Must call Transition
    }

    void changeIdle()
    {
        animator.SetInteger("State", 0);
        currState = State.Idle;
        invoked = false;
    }

    public void Die()
    {
        animator.SetBool("IsLive", false);
        live = false;
        CancelInvoke("changeWalk");
        CancelInvoke("changeIdle");
    }
}
