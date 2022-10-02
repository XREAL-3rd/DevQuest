using System;
using UnityEngine;

public class Item : MonoBehaviour
{
    //SO
    [SerializeField] private ItemType type;

    private void Start()
    {
        Instantiate(type.SpawnVFX, transform);
    }

    //충돌 시
    private void OnCollisionEnter(Collision collision)
    {
        //대상이 플레이어인지 확인하고
        var player = collision.gameObject.GetComponent<PlayerControl>();
        if (player != null)
        {
            //VFX 출력 및 효과 부여, 소멸
            player.itemEffects.AddItem(type);
            Instantiate(type.ConsumeVFX, player.transform);
            ItemFactory.Instance.Release(this);
        }
    }
}