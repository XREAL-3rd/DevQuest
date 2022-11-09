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
        setArrow();
    }

    private void Start()
    {
    }

    private void Update()
    {
        rb.MovePosition(rb.position + dir * Time.deltaTime * speed);
    }

    public void setArrow()
    {
        rb = transform.Find("ArrowCube").gameObject.GetComponent<Rigidbody>();

    }

    public void setDir(Vector3 v)
    {
        dir = v - rb.transform.position;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 6) // ground layer인 과녁이나 바닥에 화살이 맞은 경우
        {
            //rb.isKinematic = true;
            //collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            //rb.MovePosition(collision.gameObject.GetComponent<Rigidbody>().position);
            rb.position = collision.gameObject.GetComponent<Rigidbody>().position;
            //speed = -speed;
        }
    }
}
