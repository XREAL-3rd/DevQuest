using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody myRigid;
    ShotGunImg shotGunAble;

    enum State { Idle, Walk, Crawl };
    State currState;
    public bool rebounding = false;

    Vector3 playerPosition;
    Vector3 YDirection = new Vector3(0, 1, 0);
    Vector3 XDirection = new Vector3(1, 0, 0);
    Vector3 ZDirection = new Vector3(0, 0, 1);
    public Transform Cam;
    public int Bullets = 10;
    public Transform Gun;

    static float moveSpeed = 30.0f;
    static float rotateSpeed = 60.0f;
    public Vector3 front;

    // position of shotgun and effect
    public Transform FirePos;
    public GameObject FireEffect;
    public GameObject FakeBullet;
    public AudioSource shotgun;

    void Start()
    {
        myRigid = GetComponent<Rigidbody>();
        shotGunAble = GameObject.Find("ShotGunAble").GetComponent<ShotGunImg>();
        currState = State.Idle;
    }

    void Update()
    {
        StateManage();
    }

    public void StateManage()
    {
        if(!rebounding && Input.GetKeyDown(KeyCode.K))
        {
            shotGun();
            rebounding = true;
            rebound();
        }
        else if (Input.GetKey(KeyCode.C))
        {
            Crawl();
            currState = State.Crawl;
        }
        else if (Input.anyKey)
        {
            Stand();
            currState = State.Walk;
            Move();
        }
        else
        {
            Stand();
            currState = State.Idle;
        }
    }

    public void Aim(Vector3 targetPos)
    {
        Vector3 target = new Vector3(targetPos.x, FirePos.position.y, targetPos.z);
        transform.LookAt(target);
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

    public bool IsBullet()
    {
        if (Bullets > 0)
            return true;
        return false;
    }

    public void Incr(int num)
    {
        Bullets += num;
        GameControl.main.text.changeText();
    }

    public void Decr()
    {
        Bullets--;
        GameControl.main.text.changeText();
    }

    public void rebound()
    {
        Vector3 currRot = Gun.eulerAngles;
        Vector3 upward = new Vector3(0, 0, 10);
        Gun.eulerAngles = currRot + upward;
        StartCoroutine(_rebound(currRot));
    }

    IEnumerator _rebound(Vector3 currRot)
    {
        int i = 0;
        while (i++ < 1000)
        {
            Gun.rotation = Quaternion.Lerp(Gun.rotation, Quaternion.Euler(currRot), 6 * Time.deltaTime);
            yield return null;
        }
        Gun.eulerAngles = currRot;
        rebounding = false;
        shotGunAble.shotGunAble();
        yield break;
    }

    public void Crawl()
    {
        if(currState != State.Crawl)
        {
            Gun.position = Gun.position - YDirection;
        }
        Move();
    }

    public void Stand()
    {
        if(currState == State.Crawl)
        {
            Gun.position = Gun.position + YDirection;
        }
    }

    public void shotGun()
    {
        int i = 0;
        while (i++ < 3)
        {
            GameObject tempBullet = Instantiate(FakeBullet, FirePos.transform.position, FirePos.transform.rotation);
            tempBullet.GetComponent<FakeBullet>().Boom();
            Destroy(tempBullet, 2.0f);
        }
        Debug.Log("¹üÀÎ\n");
        shotgun.Play();
        GameObject spark = Instantiate(FireEffect, FirePos.position, Quaternion.identity);
        spark.transform.SetParent(this.transform);
        Destroy(spark, 1.0f);
        shotGunAble.shotGunDisable();
    }
}