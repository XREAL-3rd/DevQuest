using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    private Transform trans;
    private Rigidbody rb;
    private Vector3 shootDir;
    [SerializeField] private float force;

    public void Start(){
        rb = GetComponent<Rigidbody>();
        trans = GetComponent<Transform>();
        shootDir = new Vector3(trans.forward.x, trans.forward.y, trans.forward.z);
        rb.AddForce(shootDir * force);
    }
}
