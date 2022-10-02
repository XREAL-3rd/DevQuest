using System;
using UnityEngine;
using UnityEngine.PlayerLoop;

//발사체(Arrow) 스크립트
public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 15;
    [SerializeField] public float damage = 20;
    [SerializeField] private ParticleSystem hitVFX;

    private float time;

    //충돌하면
    private void OnCollisionEnter(Collision collision)
    {
        //충돌 대상이 Target인지 확인하고
        var target = collision.gameObject.GetComponent<Target>();
        if (target != null)
        {
            //맞으면 VFX 생성 및 Target에 데미지
            Instantiate(hitVFX, transform.position, transform.rotation);
            target.Damage(damage);
        }

        //소멸
        Destroy(gameObject);
    }

    //바닥 뚫기 방지, 음수 y좌표에서 VFX 출력하고 소멸
    private void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (transform.position.y < 0)
        {
            Destroy(gameObject);
            Instantiate(hitVFX, transform.position, transform.rotation);
        }
        else if (time >= lifetime) Destroy(gameObject);
    }
}