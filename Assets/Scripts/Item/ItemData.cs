using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData", menuName = "ItemScriptable/CreateItemData", order = int.MaxValue)]
public class ItemData : ScriptableObject {
    public enum ItemEffect {POWER, SPEED};

    [SerializeField]
    private GameObject effectFxPrefab;

    [SerializeField]
    private Vector3 fxOffset;
    public Vector3 FxOffset { get { return fxOffset; } }

    [SerializeField]
    private ItemEffect itemEffect;
    public ItemEffect Effect { get { return itemEffect; } set { itemEffect = value; } }

    [SerializeField]
    private float effectDuration;
    public float EffectDuration { get { return effectDuration; } set { effectDuration = value; } }

    public IEnumerator PowerEffect(GameObject player) {
        Instantiate(effectFxPrefab, player.transform.position + fxOffset, Quaternion.identity);
        player.GetComponent<PlayerStatus>().PhysicalDamage = 20f;
        player.GetComponent<PlayerStatus>().MagicalDamage = 20f;
        yield return new WaitForSeconds(effectDuration);
        player.GetComponent<PlayerStatus>().PhysicalDamage = 10f;
        player.GetComponent<PlayerStatus>().MagicalDamage = 10f;
    }

    public IEnumerator SpeedEffect(GameObject player) {
        Instantiate(effectFxPrefab, player.transform.position + fxOffset, Quaternion.Euler(-90, 0, 0));
        player.GetComponent<PlayerControl>().MoveSpeed = 40f;
        yield return new WaitForSeconds(effectDuration);
        player.GetComponent<PlayerControl>().MoveSpeed = 20f;
    }
}