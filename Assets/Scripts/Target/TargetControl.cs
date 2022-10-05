using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TargetControl : MonoBehaviour {
public static int hitdamage = 1;


int hp = 10;
public void Hit(Ray ray) {
    hp -= hitdamage;


    if (hp == 0) {
        Destroy(this.gameObject);
        Debug.Log("Target is destroyed!");
    }
}
}
