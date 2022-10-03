using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawn : MonoBehaviour
{
    public enum ItemType {Health, Speed};
    [SerializeField]
    private List<ItemData> itemDatas;
    [SerializeField]
    private GameObject itemPrefab;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < itemDatas.Count; i++){
            var item = SpawnItem((ItemType)i);
            item.WatchItemData();
        }
    }

    // Update is called once per frame
    public Item SpawnItem(ItemType type)
    {
        var newItem = Instantiate(itemPrefab).GetComponent<Item>();
        newItem.itemData = itemDatas[(int)type];
        newItem.name = newItem.itemData.itemName;
        return newItem;
    }
}
