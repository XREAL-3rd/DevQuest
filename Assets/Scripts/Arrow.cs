using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Vector3 dir = new Vector3(0, 0, 0);
    private Rigidbody rb;
    [SerializeField] float speed = 2f;

    private void Awake()
    {
        rb = transform.Find("ArrowCube").gameObject.GetComponent<Rigidbody>();
    }

    private void Start()
    {
       
    }

    private void Update()
    {
        rb.MovePosition(rb.position + dir * Time.deltaTime * speed);
    }

    public void setDir(Vector3 v)
    {
        dir = v - rb.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) // ground layer�� �����̳� �ٴڿ� ȭ���� ���� ���
        {
            //rb.isKinematic = true;
            //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            speed = 0;
        }
    }
}
