using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcMove : MonoBehaviour
{
    OrcAnim OrcControl;
    public Rigidbody rbody;
    public Transform transform;
    enum State { Turn, Walk, Run, Idle }
    State state;
    float rotateSpeed = 5.0f;
    bool turned = true;

    // Start is called before the first frame update
    void Start()
    {
        OrcControl = GetComponent<OrcAnim>();
        rbody = GetComponent<Rigidbody>();
        transform = GetComponent<Transform>();
        state = State.Idle;
    }

    // Update is called once per frame
    void Update()
    {
        if (!OrcControl.live)
        {
            rotateSpeed = 0.0f;
        }
        else if (state == State.Turn && !turned)
        {
            turned = true;
            StartCoroutine(Turn());
        }
        else if(state == State.Walk)
        {
            Move(12.0f);
        }
        else if(state == State.Run)
        {
            Move(20.0f);
        }
    }

    public void changeState(int num)
    {
        if(num == 0)
        {
            turned = false;
            state = State.Turn;
        }
        else if(num == 1)
        {
            state = State.Walk;
        }else if(num == 2)
        {
            state = State.Run;
        }
        else
        {

        }
    }

    IEnumerator Turn()
    {
        // 180 deg turn
        Vector3 addRot = new Vector3(0, 180, 0);
        Vector3 targetRot = transform.eulerAngles + addRot;
        int i = 0;
        while (i++ < 1000)
        {
            if (!OrcControl.live)
            {
                yield break;
            }
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRot), rotateSpeed * Time.deltaTime);
            yield return null;
        }
        transform.eulerAngles = targetRot;
        yield break;
    }

    public void Move(float moveSpeed)
    {
        Vector3 playerPosition = transform.position + transform.forward * moveSpeed * Time.deltaTime;
        rbody.MovePosition(playerPosition);
    }

    public void changeDir()
    {

    }
}
