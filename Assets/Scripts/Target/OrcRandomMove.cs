using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcRandomMove : MonoBehaviour
{
    public Rigidbody rbody;
    public Transform transform;
    enum State { Idle, Walk, Run, Attack, Turn };
    State state;
    float rotateSpeed = 5.0f;
    bool turned = true;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        state = State.Turn;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.Walk)
        {
            Move(12.0f);
        }
        else if (state == State.Run)
        {
            Move(20.0f);
        }
        else if(state == State.Idle && !turned)
        {
            turned = true;
            StartCoroutine(_Turn());
        }
    }

    public void _changeRandState(int cur)
    {
        if(cur == 0)
        {
            turned = false;
            state = State.Idle;
        }
        else if (cur == 1)
        {
            Debug.Log("here");
            state = State.Walk;
        }
        else if (cur == 2)
        {
            state = State.Run;
        }
        else
        {
            state = State.Attack;
        }
    }


    public void Move(float moveSpeed)
    {
        Vector3 playerPosition = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        rbody.MovePosition(playerPosition);
    }

    IEnumerator _Turn()
    {
        // 180 deg turn
        Vector3 addRot = new Vector3(0, 90, 0);
        Vector3 targetRot = transform.eulerAngles + addRot;
        int i = 0;
        while (i++ < 1000)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRot), 5.0f * Time.deltaTime);
            yield return null;
        }
        transform.eulerAngles = targetRot;
        yield break;
    }
}
