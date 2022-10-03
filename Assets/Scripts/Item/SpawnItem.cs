using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItem : MonoBehaviour
{
    public enum ItemType { Small, Regular, Large };
    public List<ItemScriptable> ItemList = new List<ItemScriptable>();
    public static SpawnItem ItemHandler;

    public GameObject ItemPrefab;

    private void Awake()
    {
        ItemHandler = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnItemObject();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnItemObject()
    {
        for(int i = 0; i < ItemList.Count; i++)
        {
            var item = SpawnItemFunc((ItemType)i);
            item.WatchItemInfo();
        }
    }

    public ItemBox SpawnItemFunc(ItemType type)
    {
        Vector3 spawnPos = new Vector3(transform.position.x + Random.Range(-5.0f, 5.0f), 1.2f, transform.position.z + Random.Range(-5.0f, 5.0f));
        var newItem = Instantiate((ItemPrefab).GetComponent<ItemBox>(), spawnPos, Quaternion.identity);
        newItem.ItemData = ItemList[(int)(type)];
        return newItem;
    }
}
