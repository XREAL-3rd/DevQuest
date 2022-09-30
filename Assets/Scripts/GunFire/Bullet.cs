using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bullet : MonoBehaviour
{
    [HideInInspector] public CamFollow cam;
    public Transform startFire;
    Vector3 bulletPosition;
    float moveSpeed = 50.0f;
    Rigidbody myRigid;
    Vector3 dir;

    void Start()
    {
        cam = GameObject.Find("Main Camera").GetComponent<CamFollow>();
        bulletPosition = this.transform.position;
        myRigid = GetComponent<Rigidbody>();
        
        // in case the savedAim destoryed right after the bullet created
        if (cam.savedAim)
        {
            dir = (cam.savedAim.position - cam.FirePos.position).normalized;
        }
        else
        {
            dir = -this.transform.right;
        }
    }

    void Update()
    {        //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의 힘만큼 날아가라

        // this.transform.Translate(dir* 0.1f);
        bulletPosition +=  dir* moveSpeed * Time.deltaTime;

        myRigid.MovePosition(bulletPosition);
    }
}