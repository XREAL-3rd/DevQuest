using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField]
	ItemData itemData;
	public ItemData ItemData { set { itemData = value; } }


	float rotSpeed = 100f;

	void Awake()
	{
		Destroy(this.gameObject, 10.0f);
	}

	void Update()
	{
		transform.Rotate(new Vector3(0, rotSpeed * Time.deltaTime, 0));
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
		{
			ItemManager.main.itemEffect(itemData);
			Destroy(gameObject);
		}
	}
}
