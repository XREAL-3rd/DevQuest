using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcRandom : MonoBehaviour
{
    Animator animator;
    OrcRandomMove Orc;
    enum State { Idle, Walk, Run, Attack, Turn };
    State currState;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Orc = GetComponent<OrcRandomMove>();
        currState = State.Idle;
        changeRandomState();
    }

    // Update is called once per frame
    void Update()
    {

    }


    void changeRandomState()
    {
        Invoke("changeRandomState", 5.0f+Random.Range(0.0f, 4.0f));
        int rand = Random.Range(0, 4);
        Orc._changeRandState(rand);
        if (rand == 0)
        {
            _changeIdle();
        }
        else if (rand == 1)
        {
            _changeWalk();
        }
        else if (rand == 2)
        {
            _changeRun();
        }
        else
        {
            _changeAttack();
        }
    }

    void _changeIdle()
    {
        animator.SetInteger("State", 0);
        currState = State.Idle;
    }

    void _changeWalk()
    {
        animator.SetInteger("State", 1);
        currState = State.Walk;
    }

    void _changeRun()
    {
        animator.SetInteger("State", 2);
        currState = State.Run;
    }

    void _changeAttack()
    {
        animator.SetInteger("State", 3);
        currState = State.Attack;
    }
}
