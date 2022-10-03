using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager main;
    public List<ItemData> ItemDatas = new List<ItemData>();
    public GameObject itemBox;
    public PlayerControl player;

    private GameObject playereffect;

    void Awake()
    {
        main = this;
        Invoke("SpawnItemObject", 2.0f);
    }

    public void SpawnItemObject()
    {
        float ranX = Random.Range(-30, 30);
        float ranZ = Random.Range(-10, 30);
        Vector3 ranPos = new Vector3(ranX, 2f, ranZ);

        var newItem = Instantiate(itemBox, ranPos, Quaternion.identity).GetComponent<Item>();
        newItem.ItemData = ItemDatas[Random.Range(0, ItemDatas.Count)];

        Invoke("SpawnItemObject", 5.0f);
    }

    public void itemEffect(ItemData effect)
	{
        CancelInvoke("normalState");
        if (playereffect) Destroy(playereffect);

        player.moveSpeed = effect.Speed;
        player.jumpAmount = effect.Jump;
        playereffect = Instantiate(effect.Effect, player.transform);
        Invoke("normalState", 8.0f);
	}

    public void normalState()
	{
        player.moveSpeed = 6.5f;
        player.jumpAmount = 8f;
        Destroy(playereffect);
	}
}