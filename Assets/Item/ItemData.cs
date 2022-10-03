using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Scriptable Object/Item Data", order = int.MaxValue)]
public class ItemData : ScriptableObject
{

    [SerializeField]
    private string Name;
    public string itemName { get {return Name;} set {Name = value;}}
    [SerializeField]
    private int hp;
    public int HP { get {return hp;} set {hp = value;}}
    [SerializeField]
    private int speed;
    public int Speed { get {return speed;} set {speed = value;}}
    [SerializeField]
    private int number;
    public int Number { get {return number;} set {number = value;}}
    [SerializeField]
    private int frequency;
    public int Frequency { get {return frequency;} set {frequency = value;}}

}
