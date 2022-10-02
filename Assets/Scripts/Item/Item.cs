using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{

     [SerializeField] private ItemSO itemso;

     private void OnCollisionEnter(Collision collision)
    {
       GameObject tmp = collision.gameObject; 

        if (tmp.name.Contains("Player")) 
    
        {
            HitDamage();
            JumpUp();
            Destroy(this.gameObject, 0.5f);
            Debug.Log("Item");
        }
    }
    void HitDamage() //itemSO의 hitdamage를 TargetControl의 hitdamage에 저장
    {
        TargetControl.hitdamage = itemso.HitDamage;
    }
    void JumpUp() //itemSO의 점프 값을 PlayerControl의 jumpAmount에 저장 
    {
        PlayerControl.jumpAmount = itemso.JumpUp;
    }
}
