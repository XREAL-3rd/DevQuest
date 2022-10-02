using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static ItemData;

public class Item : MonoBehaviour {
    [SerializeField]
    private ItemData itemData;
    private GameObject effectFx;

    private void OnTriggerEnter(Collider other) {
        if (!other.CompareTag("Player"))
            return;
        
        Destroy(gameObject);
        ApplyEffect(other.gameObject);
    }

    private void ApplyEffect(GameObject player) {
        switch (itemData.Effect) {
            case ItemEffect.POWER:
                StartCoroutine(itemData.PowerEffect(player));
                break;
            case ItemEffect.SPEED:
                StartCoroutine(itemData.SpeedEffect(player));
                break;
        }
    }
}
