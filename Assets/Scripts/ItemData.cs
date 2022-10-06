using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData", order = int.MaxValue)]
public class ItemData: ScriptableObject
{
	[SerializeField]
    private float jumpAmount;
    public float JumpAmount { get { return jumpAmount; } set { jumpAmount = value; } }

    [SerializeField]
    private float speed;
    public float Speed { get { return speed; } set{ speed = value; } }
}
