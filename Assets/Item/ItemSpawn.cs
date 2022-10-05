using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ItemSpawn : MonoBehaviour
{
    public enum ItemType {Health, Speed};
    [SerializeField]
    private List<ItemData> itemDatas = new List<ItemData>();
    [SerializeField]
    private GameObject itemPrefab;


    // Start is called before the first frame update
    private void Start()
    {
        for (int i = 0; i < itemDatas.Count; i++){
            var item = SpawnItem((ItemType)i);
            item.WatchItemData();
        }
    }

    public Item SpawnItem(ItemType type)
    {
        GameObject gameItem;
        var random_position = new Vector3(Random.Range(-5f, 5f), 0, Random.Range(-5f, 5f));
        gameItem = Instantiate(itemPrefab, random_position, Quaternion.identity);
        
        var newItem = gameItem.GetComponent<Item>();
        newItem.ItemData = itemDatas[(int)(type)];
        return newItem;
    }
}
