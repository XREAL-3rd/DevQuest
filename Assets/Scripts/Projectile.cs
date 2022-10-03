using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Transform trans;
    private Rigidbody rb;
    private Vector3 shootDir;
    [SerializeField] private float force;

    public void SetUp(Transform pos, Vector3 dir){
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        shootDir = dir;
        trans = pos;
    }

    public void Fire(){
        Vector3 shoot_dir;
        shoot_dir = this.shootDir.normalized;
        rb.AddForce(shoot_dir * force);
    }
}
