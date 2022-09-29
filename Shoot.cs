using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject Bullet;
    public Transform FirePos;  //총구

    //총알 발사
    public Camera mainCamera;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            //충돌과 상관없이 만들어지는 총알
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);

            if (Physics.Raycast(ray, out hit,100f))
            {
                transform.LookAt(hit.point);  //클릭한 방향 바라보기

                // 충돌한 상대방으로부터 IDamageable 오브젝트를 가져오기 시도
                var target =
                    hit.collider.GetComponent<IDamageable>();

                // 상대방으로 부터 IDamageable 오브젝트를 가져오는데 성공했다면
                if (target != null)
                {
                    DamageMessage damageMessage;

                    damageMessage.damager = this.gameObject;
                    damageMessage.amount = 25f;
                    damageMessage.hitPoint = hit.point;
                    damageMessage.hitNormal = hit.normal;

                    // 상대방의 OnDamage 함수를 실행시켜서 상대방에게 데미지 주기
                    target.ApplyDamage(damageMessage);

                    //총알 이동: 근데 총알이 안 보임(속도 1f로 해도 마찬가지)
                    Bullet.transform.position = Vector3.MoveTowards(Bullet.transform.position, hit.point, 1f);
                }
            }
            //충돌 안해도 잘가야 함
            else
            {
                Bullet.transform.position = Vector3.MoveTowards(Bullet.transform.position, ray.direction * 100f, 1f);
            }

            if (Mathf.Abs(Bullet.transform.position.x) >= 100 || Mathf.Abs(Bullet.transform.position.z) >= 100)
            {
                Bullet.SetActive(false);
                Destroy(Bullet);
            }

        }
    }
    private void OnTriggerEnter(Collider other)  //충돌하면 사라지기
    {
        if (other.tag == "Enemy")
        {
            Bullet.GetComponent<SphereCollider>().enabled = false;
            Bullet.SetActive(false);
            Destroy(Bullet);
        }
    }
}
