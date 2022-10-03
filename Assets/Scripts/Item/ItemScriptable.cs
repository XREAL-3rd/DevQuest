using UnityEngine;

[CreateAssetMenu(fileName = "Item Data", menuName = "Item Scriptable/Item Data", order = int.MaxValue)]
public class ItemScriptable : ScriptableObject
{
    [SerializeField]
    private string ItemName;
    public string Name { get { return ItemName; } set { ItemName = value; } }

    [SerializeField]
    private int BulletNum;
    public int Bullets { get { return BulletNum; } set { BulletNum = value; } }

    [SerializeField]
    private float BoxSize;
    public float Size { get { return BoxSize; } set { BoxSize = value; } }

    [SerializeField]
    private GameObject CollisionEffect;
    public GameObject Effect { get { return CollisionEffect; } set { CollisionEffect = value; } }
}
