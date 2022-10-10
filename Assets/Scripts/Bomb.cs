using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosionParticle;

    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            Instantiate(explosionParticle, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    /*
    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
     */
}
