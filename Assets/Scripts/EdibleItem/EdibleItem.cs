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
        IncreasePlayerSpeed();
        DestroyItem();
    }

    private void DestroyItem()
    {
        Instantiate(itemData.eatenEffect, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);

        EdibleItemManager.main.OnItemEaten(gameObject);
    }

    private void IncreasePlayerSpeed()
    {
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerControl>();
        player.moveSpeed += itemData.increasingSpeed;
    }
}