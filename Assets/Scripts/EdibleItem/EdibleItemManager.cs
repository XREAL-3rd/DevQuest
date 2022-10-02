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
    [SerializeField] private Transform playerTransform;

    private readonly List<GameObject> activeItems = new List<GameObject>();

    private void Awake()
    {
        main = this;
        
        InitialSpawn();
    }

    private void InitialSpawn()
    {
        for (int idx = 0; idx < items.Count; idx++)
        {
            for (int j = 0; j < 5; j++)
            {
                SpawnItem((ItemType) idx);
            }
        }
    }

    private void SpawnItem(ItemType type)
    {
        var itemData = items[(int)(type)];
        
        float angle = Random.Range(0f, 360f);
        Vector3 spawnPos = playerTransform.position - new Vector3(Mathf.Sin(angle), 0.1f, Mathf.Cos(angle)) * 10;

        var newItem = Instantiate(itemData.prefab);
        newItem.gameObject.transform.position = spawnPos;
        newItem.gameObject.transform.SetParent(GameObject.Find("EdibleItems").transform);
        newItem.AddComponent<EdibleItem>().ItemData = items[(int) type];

        AddItemToList(newItem);
    }

    public void AddItemToList(GameObject item)
    {
        activeItems.Add(item);
    }

    public void DeleteItemFromList(GameObject item)
    {
        activeItems.Remove(item);
    }
}
