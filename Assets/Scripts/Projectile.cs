using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Transform proj;
    private Rigidbody rb;
    private Vector3 shootDir;
    [SerializeField] private float force;


    public void SetUp(Vector3 dir){
        shootDir = dir;
        rb = GetComponent<Rigidbody>();
    }

    public void Fire(){
        Vector3 shoot_dir;
        shoot_dir = this.shootDir.normalized;
        rb.AddForce(shoot_dir * force);
    }
}
