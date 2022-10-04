using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrcLife : MonoBehaviour
{
    public GameObject bloodEffect;
    public GameObject fireEffect;
    public GameObject Orc;
    OrcAnim OrcControl;
    public int life = 6;
    // Start is called before the first frame update
    void Start()
    {
        OrcControl = GetComponent<OrcAnim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (life < 1)
        {
            Debug.Log("Dead\n");
            OrcControl.Die();
            Destroy(Orc, 3.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit\n");
            life -= 1;
            showEffect(collision);
        }
        else if (collision.collider.gameObject.CompareTag("ShotGun"))
        {
            Debug.Log("ShotGun hit\n");
            life -= 1;
            showEffectShotGun(collision);
        }
    }

    private void showEffect(Collision collision)
    {
        // 충돌 지점
        ContactPoint contact = collision.contacts[0];
        // contact.normal: 충돌지점의 법선 백터
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        GameObject spark = Instantiate(bloodEffect, contact.point, rot);
        spark.transform.SetParent(this.transform);
        Destroy(spark, 1.0f);
    }

    private void showEffectShotGun(Collision collision)
    {
        // 충돌 지점
        ContactPoint contact = collision.contacts[0];
        // contact.normal: 충돌지점의 법선 백터
        GameObject fire = Instantiate(fireEffect, contact.point, Quaternion.identity);
        fire.transform.SetParent(this.transform);
        Destroy(fire, 1.0f);
    }
}
