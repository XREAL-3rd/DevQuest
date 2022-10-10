using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// 각 item에 붙을거다 

public class GetDataFromSO : MonoBehaviour
{

    // data 값 받아오기
    public ItemData itemData;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject; // 일단 충돌체 정보 받아주고
        print("충돌체 정보" + temp);

        if (temp.name.Contains("Player")) // 만약 충돌체가 player이면 
        {

            //각 함수들 실행 해주고 
            UICheck();
            HitDamage();
            Speed();
            VFX();

            // 0.5초 뒤에 이 게임오브젝트 없애주기 
            Destroy(this.gameObject, 0.5f);

        }
    }

    void HitDamage() // Fireball의 Hit Damage 바꿔주기
    {
        FireBall.hitDamage = itemData.HitDamage;
    }

    void Speed() // player의 speed 바꿔주기 
    {
        PlayerControl.moveSpeed = itemData.Speed;
    }

    void VFX() // 이 VFX Instantiate 해주기
    {
       GameObject vfxTemp= Instantiate(itemData.vfx);
        vfxTemp.transform.position = gameObject.transform.up;
    }

    void UICheck()
    {
        if (gameObject.name.Contains("Run")) // 체리면
        {
            
            Image cherryUI = GameObject.Find("Image_Cherry").GetComponent<Image>();
            cherryUI.enabled = true;
        }
        if (gameObject.name.Contains("Damage")) // 체리면
        {
            Image lemonUI = GameObject.Find("Image_Lemon").GetComponent<Image>();
            lemonUI.enabled = true;
        }
    }
}
