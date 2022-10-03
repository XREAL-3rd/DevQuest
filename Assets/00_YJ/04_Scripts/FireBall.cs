using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall : MonoBehaviour
{
    public static int hitDamage = 35;

    private void OnCollisionEnter(Collision collision)
    {
            Destroy(this.gameObject);
    }
}

