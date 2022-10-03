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
        var newItem = Instantiate(itemPrefab).GetComponent<Item>();
        
        // 여기서 null return 하는데 instantiate이 잘못된 건지?
        Debug.Log(newItem);
        newItem.ItemData = itemDatas[(int)(type)];
        return newItem;
    }
}
