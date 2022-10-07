using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// �� item�� �����Ŵ� 

public class GetDataFromSO : MonoBehaviour
{

    // data �� �޾ƿ���
    public ItemData itemData;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject; // �ϴ� �浹ü ���� �޾��ְ�
        print("�浹ü ����" + temp);

        if (temp.name.Contains("Player")) // ���� �浹ü�� player�̸� 
        {

            //�� �Լ��� ���� ���ְ� 
            UICheck();
            HitDamage();
            Speed();
            VFX();

            // 0.5�� �ڿ� �� ���ӿ�����Ʈ �����ֱ� 
            Destroy(this.gameObject, 0.5f);

        }
    }

    void HitDamage() // Fireball�� Hit Damage �ٲ��ֱ�
    {
        FireBall.hitDamage = itemData.HitDamage;
    }

    void Speed() // player�� speed �ٲ��ֱ� 
    {
        PlayerControl.moveSpeed = itemData.Speed;
    }

    void VFX() // �� VFX Instantiate ���ֱ�
    {
       GameObject vfxTemp= Instantiate(itemData.vfx);
        vfxTemp.transform.position = gameObject.transform.up;
    }

    void UICheck()
    {
        if (gameObject.name.Contains("Run")) // ü����
        {
            
            Image cherryUI = GameObject.Find("Image_Cherry").GetComponent<Image>();
            cherryUI.enabled = true;
        }
        if (gameObject.name.Contains("Damage")) // ü����
        {
            Image lemonUI = GameObject.Find("Image_Lemon").GetComponent<Image>();
            lemonUI.enabled = true;
        }
    }
}
