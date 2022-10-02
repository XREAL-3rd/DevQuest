using UnityEngine;

namespace DefaultNamespace
{
    [CreateAssetMenu(fileName = "ItemType", menuName = "Item/Type", order = 0)]
    public class ItemType : ScriptableObject
    {
        [SerializeField] private GameObject spawnVFX;
        public GameObject SpawnVFX => spawnVFX;

        [SerializeField] private GameObject consumeVFX;
        public GameObject ConsumeVFX => consumeVFX;

        [SerializeField] private float addDamage;
        public float AddDamage => addDamage;

        [SerializeField] private float agility;
        public float Agility => agility;

        [SerializeField] private float jumpMul;
        public float JumpMul => jumpMul;
    }
}