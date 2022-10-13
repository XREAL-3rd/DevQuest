using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemEffectFx : MonoBehaviour {
    [SerializeField]
    private ItemData itemData;
    private Transform player;
    private float timer;

    private void OnEnable() {
        player = GameObject.Find("Player").GetComponent<Transform>();
        timer = 0;
    }

    private void Update() {
        transform.position = player.position + itemData.FxOffset;
        timer += Time.deltaTime;
        if(timer > itemData.EffectDuration)
            Destroy(gameObject);
    }
}