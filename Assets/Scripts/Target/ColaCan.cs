using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColaCan : MonoBehaviour
{
    public GameObject sparkEffect;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("Cola hit\n");
            showEffect(collision);
        }
    }

    private void showEffect(Collision collision)
    {
        // �浹 ����
        ContactPoint contact = collision.contacts[0];
        // contact.normal: �浹������ ���� ����
        Quaternion rot = Quaternion.FromToRotation(-Vector3.forward, contact.normal);
        GameObject spark = Instantiate(sparkEffect, contact.point, rot);
        spark.transform.SetParent(this.transform);
        Destroy(spark, 1.0f);
        //�Ҹ�
        audioSource.Play();
    }
}
