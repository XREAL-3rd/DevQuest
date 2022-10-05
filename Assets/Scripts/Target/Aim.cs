using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public int life = 4;
    public GameObject sparkEffect;
    public GameObject fireEffect;
    public Material spice;
    public Material shingle;
    //private GameObject thisAim;
    

    // Start is called before the first frame update
    void Start()
    {
        //thisAim = GetComponent<GameObject>();
        if (GameControl.main.targetNum)
        {
            GameControl.main.targetNum.Incr();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit\n");
            life -= 1;
            showEffect(collision);
        }else if (collision.collider.gameObject.CompareTag("ShotGun"))
        {
            Debug.Log("ShotGun hit\n");
            life -= 1;
            showEffectShotGun(collision);
        }
    }

    public void changeRed()
    {
        GetComponent<MeshRenderer>().material = spice;
    }

    public void changeInit()
    {
        GetComponent<MeshRenderer>().material = shingle;
    }

    private void showEffect(Collision collision)
    {
        // 충돌 지점
        ContactPoint contact = collision.contacts[0];
        // contact.normal: 충돌지점의 법선 백터
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        GameObject spark = Instantiate(sparkEffect, contact.point, rot);
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
        Destroy(fire, 2.0f);
    }
}
