using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 1. 체력관리 : 세번 이상 맞으면 쓰러지기 => Slider로 값 받아와서 / 3번 에 나눠서 인식하고 / 인식 끝나면 ( 애니메이션 없앤 다음에 ) destroy object 하기
 */

public class Animal : MonoBehaviour
{
    public Slider hpbar;
    public Animator anim;
    public GameObject vfx_hit;


    [SerializeField] float maxHP;
    [SerializeField] float currentHP;


    // Start is called before the first frame update
    void Start()
    {
        maxHP = 100;
        currentHP = 100;
    }

    // Update is called once per frame
    void Update()
    {
        hpbar.value = currentHP / maxHP;

    }




    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject;


        if (temp.name.Contains("Fire")) // 총알에 맞으면 
        {
            currentHP -= FireBall.hitDamage;
            anim.SetTrigger("damage"); // 데미지 애니메이션 해주기

            // 데미지 VFX 해주기
            ContactPoint contact = collision.contacts[0]; // 충돌 지점
            GameObject tempVFX = Instantiate(vfx_hit);
            tempVFX.transform.position = contact.point; // 위치 먼저 설정
        }



        if (currentHP <= 0)
        {
            // 죽는 시늉 하고
            anim.SetTrigger("die");


            // 1초 뒤에 없애기
            Destroy(this.gameObject, 3.0f);
        }

        anim.SetTrigger("idle");
    }


}
