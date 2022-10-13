using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemData;

public class Item : MonoBehaviour {
    [SerializeField]
    private ItemData itemData;
    private bool effectApplied;

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player") || effectApplied)
            return;

        effectApplied = true;
        for(int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);

        ApplyEffect(gameObject, other.gameObject);
    }

    private void ApplyEffect(GameObject item, GameObject player) {
        switch (itemData.Effect) {
            case ItemEffect.POWER:
                StartCoroutine(itemData.ApplyPowerEffect(item, player));
                break;
            case ItemEffect.SPEED:
                StartCoroutine(itemData.ApplySpeedEffect(item, player));
                break;
        }
    }
}
