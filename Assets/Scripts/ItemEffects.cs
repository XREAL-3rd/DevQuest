using UnityEngine;

namespace DefaultNamespace
{
    public class ItemEffects
    {
        private readonly PlayerControl player;

        public float AddDamage { get; private set; }
        public float Agility { get; private set; } = 1;
        public float JumpMul { get; private set; } = 1;

        public ItemEffects(PlayerControl player)
        {
            this.player = player;
        }

        public void AddItem(ItemType item)
        {
            AddDamage += item.AddDamage;
            Agility *= item.Agility;
            JumpMul *= item.JumpMul;
            player.animator.animator.speed = Agility;
        }
    }
}