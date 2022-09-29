using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    private CamFollow camera;
    public Transform startFire;
    Vector3 bulletPosition;
    float moveSpeed = 50.0f;
    Rigidbody myRigid;
    Vector3 dir;

    void Start()
    {
        camera = GameObject.Find("Main Camera").GetComponent<CamFollow>();
        bulletPosition = this.transform.position;
        myRigid = GetComponent<Rigidbody>();
        dir = (camera.savedAim.position - camera.FirePos.position).normalized;
    }

    void Update()
    {        //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의 힘만큼 날아가라

        // this.transform.Translate(dir* 0.1f);
        bulletPosition +=  dir* moveSpeed * Time.deltaTime;

        myRigid.MovePosition(bulletPosition);
    }
}