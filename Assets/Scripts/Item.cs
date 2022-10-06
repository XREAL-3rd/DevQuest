using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    ItemData itemData;
    public ItemData ItemData { set { itemData = value; } }

    void OnCollisionEnter(Collision col)
    {
        GameObject other = col.gameObject;
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerControl>().moveSpeed = itemData.Speed;
            other.GetComponent<PlayerControl>().jumpAmount = itemData.JumpAmount;
            Destroy(gameObject);
        }
    }        
}
