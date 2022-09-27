using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{// 마우스에 따라 방향 바꾸고 bulletGenerator역할 수행

    public GameObject bulletPrefab;
    public int weight;  //속도 가중치

    RaycastHit hit;
    public int turnSpeed;
    Quaternion dr;

    public float moveSpeed;  //그라운드에서의 움직임
    private float xRotate = 0.0f; //상하 바라보기

    PlayerInput playerInput;   //컴포넌트는 start에서 할당시키자

    public void Move(Vector3 dir)
    {
        transform.Translate(dir);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void FixedUpdate()
    {
        //물리 갱신 주기에 맞춰 움직임

        float move_X = playerInput.move_x;
        float move_Z = playerInput.move_z;
        Vector3 move = new Vector3(move_X, 0, move_Z);

        Move(transform.TransformDirection(move) * Time.deltaTime*10);


    }

    // Update is called once per frame
    void Update()   
    {
       
           
        if (Input.GetMouseButton(1))  //오른쪽 버튼으로 방향 바꾸기
        {
            Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit);  //hit에 충돌정보 저장
            Vector3 click = hit.point;

            dr = Quaternion.LookRotation((click - transform.position).normalized);   //클릭한 방향으로 회전해라
            transform.rotation = Quaternion.Slerp(transform.rotation, dr, turnSpeed * Time.deltaTime); //단위 시간당 회전

        }

    }

    
}

