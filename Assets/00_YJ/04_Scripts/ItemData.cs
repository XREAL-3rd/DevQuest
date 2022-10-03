using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateData", order = int.MaxValue)]

public class ItemData : ScriptableObject
{
    [SerializeField] // 이름
    private string itemName;
    public string Name { get { return itemName; } set { itemName = value; } }

    [SerializeField] // 먹으면 올라가는 파괴력
    private int hitdamage;
    public int HitDamage { get { return hitdamage; } set { hitdamage = value; } }


    [SerializeField] // 먹으면 올라가는 스피드 
    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    //[SerializeField] // VFX
    public GameObject vfx;






}


