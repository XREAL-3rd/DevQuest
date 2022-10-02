using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "Item/Data", order = 0)]
//이름, hitdamage 변경, jump 높이 변경
public class ItemSO : ScriptableObject
{
    [SerializeField] private string itemname;
    public string Name { get { return itemname; } set { itemname = value; } }

    [SerializeField] private int hitdamage;
    public int HitDamage { get { return hitdamage; } set { hitdamage = value; } }


    [SerializeField] private float jumpup;
    public float JumpUp { get { return jumpup; } set { jumpup = value; } }

}