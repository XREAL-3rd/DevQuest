using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemData itemData;
    public ItemData ItemData { set { itemData = value; } }
    public void WatchItemData(){
        Debug.Log("NAME :: " + itemData.itemName);
        Debug.Log("FREQUENCY :: " + itemData.Frequency);
        Debug.Log("HEALTH :: " + itemData.HP);
        Debug.Log("SPEED :: " + itemData.Speed);
    }

}
