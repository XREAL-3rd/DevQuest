using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdibleItem : MonoBehaviour
{
    [SerializeField] private EdibleItemData itemData;
    public EdibleItemData ItemData
    {
        set { itemData = value; }
    }

    public void WatchInfo()
    {
        Debug.Log(itemData.increasingSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision Enter");
    }
}
