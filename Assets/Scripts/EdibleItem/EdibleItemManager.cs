using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EdibleItemManager : MonoBehaviour
{
    public static EdibleItemManager main;

    public enum ItemType { Bottle, Box };
    public List<EdibleItemData> items = new List<EdibleItemData>();

    private readonly List<GameObject> activeItems = new List<GameObject>();

    [SerializeField] private Transform playerTransform;

    private void Awake()
    {
        main = this;
        
        SpawnItem(ItemType.Bottle);
    }

    // private void InitialSpawn()
    // {
    //     for (int idx = 0; idx < items.Count; idx++)
    //     {
    //         for (int j = 0; j < 5; j++)
    //         {
    //             SpawnItem(idx);
    //         }
    //     }
    // }

    private void SpawnItem(ItemType type)
    {
        var itemData = items[(int)(type)];
        
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPos = playerTransform.position - new Vector3(Mathf.Sin(angle), 0.1f, Mathf.Cos(angle)) * 10;

        var newItem = Instantiate(itemData.prefab);
        newItem.transform.position = spawnPos;
        newItem.transform.SetParent(GameObject.Find("EdibleItems").transform);
        
        AddItemToList(newItem);
    }

    public void AddItemToList(GameObject go)
    {
        activeItems.Add(go);
    }

    public void DeleteItemFromList(GameObject go)
    {
        activeItems.Remove(go);
    }
}
