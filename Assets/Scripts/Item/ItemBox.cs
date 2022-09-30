using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBox : MonoBehaviour
{
    [SerializeField]
    ItemScriptable item_data;
    public ItemScriptable ItemData { set { item_data = value; } }

    // Start is called before the first frame update
    void Start()
    {
        SizeChange();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void WatchItemInfo()
    {
        Debug.Log(item_data.Name);
        Debug.Log(item_data.Bullets);
    }

    public void SizeChange()
    {
        this.transform.localScale = new Vector3(item_data.Size, item_data.Size, item_data.Size);
    }

    public void showEffect(Collision collision)
    {
        GameControl.main.player.Incr(item_data.Bullets);
        // 충돌 지점
        Vector3 contact = collision.collider.gameObject.GetComponent<Transform>().position;
        Vector3 upon = new Vector3(0, 1, 0);
        contact += upon;
        
        // contact.normal: 충돌지점의 법선 백터
        Quaternion rot = Quaternion.identity;
        GameObject diamond = Instantiate(item_data.Effect, contact, rot);
        diamond.transform.SetParent(this.transform);
        Destroy(diamond, 1.0f);
    }
}