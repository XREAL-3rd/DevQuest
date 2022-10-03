using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetControl : MonoBehaviour {
public GameObject hitFx;
public static int hitdamage = 1;

int hp = 10;
public void Hit(Ray ray) {
    hp -= hitdamage;
    if (hp == 0) {
       /* Instantiate(hitFx, transform.position, transform.rotation);*/
        Destroy(gameObject);
        Debug.Log("Target is destroyed!");
    }
}
}
