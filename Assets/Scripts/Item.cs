using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemType type;

        private void Start()
        {
            Instantiate(type.SpawnVFX, transform);
        }

        private void OnCollisionEnter(Collision collision)
        {
            var player = collision.gameObject.GetComponent<PlayerControl>();
            if (player != null)
            {
                player.itemEffects.AddItem(type);
                Instantiate(type.ConsumeVFX, player.transform);
                ItemFactory.Instance.Release(this);
            }
        }
    }
}