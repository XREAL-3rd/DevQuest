using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleItem : MonoBehaviour
{
    [SerializeField] private EdibleItemData itemData;
    public EdibleItemData ItemData
    {
        get { return itemData; }
        set { itemData = value; }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(itemData.eatenEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

        EdibleItemManager.main.DeleteItemFromList(gameObject);
    }
}
