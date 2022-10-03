using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItem", order = int.MaxValue)]
public class ItemData : ScriptableObject
{
    [SerializeField]
    private float jump;
    public float Jump { get { return jump; } set { jump = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    [SerializeField]
    private GameObject effect;
    public GameObject Effect { get { return effect; } set { effect = value; } }

}