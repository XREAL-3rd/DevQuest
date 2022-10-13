using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour {
    [SerializeField]
    private float physicalDamage = 10f;
    public float PhysicalDamage { get { return physicalDamage; } set { physicalDamage = value; } }
    [SerializeField]
    private float magicalDamage = 10f;
    public float MagicalDamage { get { return magicalDamage; } set { magicalDamage = value; } }
}
