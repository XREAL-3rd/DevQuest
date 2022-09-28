using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject hitEffectPreFab;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 5f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            other.gameObject.GetComponent<Target>().Hit();
            Destroy (gameObject);
            GameObject effect =
                Instantiate(hitEffectPreFab,
                transform.position,
                transform.rotation);
            Destroy(effect, 1.0f);
        }
    }
}
