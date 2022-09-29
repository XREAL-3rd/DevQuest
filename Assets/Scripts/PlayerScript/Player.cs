using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody myRigid;

    Vector3 playerPosition;
    Vector3 YDirection = new Vector3(0, 1, 0);
    Vector3 XDirection = new Vector3(1, 0, 0);
    Vector3 ZDirection = new Vector3(0, 0, 1);
    public Transform Cam;

    static float moveSpeed = 30.0f;
    static float rotateSpeed = 60.0f;
    public Vector3 front;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

    }

    public void Aim(Vector3 targetPos)
    {
        transform.LookAt(targetPos);
    }

    public void Move()
    {
        playerPosition = this.transform.position;
        front = (playerPosition - Cam.position).normalized;
        if (Input.GetKey(KeyCode.D))
        {
            playerPosition -= Vector3.Cross(front, YDirection) * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.W))
        {
            playerPosition += front * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.A))
        {
            playerPosition += Vector3.Cross(front, YDirection) * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.S))
        {
            playerPosition -= front * moveSpeed * Time.deltaTime;

            myRigid.MovePosition(playerPosition);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            this.transform.Rotate(0, -rotateSpeed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            this.transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
        }
    }
}