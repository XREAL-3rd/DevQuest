using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public static int hitDamage=34;

    private void Start()
    {
        if (this.gameObject.name.Contains("Q"))
        {
            hitDamage = 50;
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject;

        if (!temp.tag.Contains("Player"))
        {
            Destroy(this.gameObject);

        }

    }
}

