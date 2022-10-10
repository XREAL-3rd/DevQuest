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
            Collider[] targets = Physics.OverlapSphere(this.transform.position, 7f);
            foreach (Collider target in targets)
            {
                if (target.CompareTag("Target"))
                {
                    Vector3 explosion = target.transform.position - this.transform.position;
                    target.gameObject.GetComponent<Target>().attack(20, explosion);
                }

            }
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
