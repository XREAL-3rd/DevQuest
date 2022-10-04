using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FakeBullet : MonoBehaviour
{
    Vector3 bulletPosition;
    float moveSpeed = 70.0f;
    Rigidbody myRigid;
    Vector3 dir;

    void Start()
    {
        bulletPosition = this.transform.position;
        myRigid = GetComponent<Rigidbody>();
        dir = -this.transform.right;
    }

    void Update()
    {        //프레임마다 오브젝트를 로컬좌표상에서 앞으로 1의 힘만큼 날아가라

        // this.transform.Translate(dir* 0.1f);
        bulletPosition += dir * moveSpeed * Time.deltaTime;

        myRigid.MovePosition(bulletPosition);
    }

    public void Boom()
    {
        //change tag to variate the effect on the target
        gameObject.tag ="ShotGun";

        //change size
        float size = 0.2f;
        this.transform.localScale = new Vector3(size, size, size);

        //방향 랜덤
        Vector3 newDir = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
        this.transform.eulerAngles = this.transform.eulerAngles + newDir;
    }
}