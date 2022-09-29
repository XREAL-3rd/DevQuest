using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShoot : MonoBehaviour
{
    private float bullet_speed = 20f;
    private Rigidbody bullet_rb;
    private Vector3 bullet_movementInput;
    public GameObject prefabBullet;
    private GameObject bullet;
    //public GameObject cloud;
    private bool isMouseDown = false;


    void Start()
    {
        //cloud.SetActive(false);
        //bullet_rb = GetComponent<Rigidbody>();
        //newbullet = Instantiate(bullet, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
    }

    public void Bullet_follow_Mouse()
    {
        //Input.mousePosition = bullet.transform();
    }

    private void OnMouseDown()
    {
        bullet = Instantiate(prefabBullet, new Vector3(0, 0, -10), new Quaternion(0, 0, 0, 0));
        Destroy(bullet, 5f);
        //Vector3 mouse_position = Input.mousePosition;
       //bullet_movementInput = new Vector3(mouse_position.x, mouse_position.y,);
        //Physics.Raycast(mouse_position, new Vector3(0, 0, 1), out RaycastHit hitInfo);
        //Debug.Log(hitInfo.collider.name);
        bullet_movementInput = Input.mousePosition;
        isMouseDown = true;
        Debug.Log("Mouse Button on Bullet is clicked.");
    }
    void Update()
    {
        if (isMouseDown==true)
        {
            //bullet_rb.MovePosition(bullet_rb.position + bullet_movementInput * bullet_speed * Time.deltaTime);
            bullet.transform.position = Vector3.MoveTowards(bullet.transform.position, transform.position, Time.deltaTime * bullet_speed);

        }
    }

    //Cloud한테 달린 스크립트라.. 
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.name== "Bullet(Clone)")
        {
            Destroy(bullet);
            Debug.Log("Bullet Destroyed");
        }
    }
}
