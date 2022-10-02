using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

namespace DefaultNamespace
{
    public class ItemFactory : MonoBehaviour
    {
        public static ItemFactory Instance { get; private set; }

        [SerializeField] private Item itemPrefab;
        [SerializeField] private float interval;
        [SerializeField] private int maxCount;
        [SerializeField] private Rect area;

        private ObjectPool<Item> itemPool;
        private float progress;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }

            Instance = this;
            itemPool = new ObjectPool<Item>(
                () => Instantiate(itemPrefab, transform),
                item =>
                {
                    item.gameObject.SetActive(true);
                    item.transform.position = new(Random.Range(area.xMin, area.xMax), 0,
                        Random.Range(area.yMin, area.yMax));
                },
                item => item.gameObject.SetActive(false),
                Destroy
            );
        }

        private void Update()
        {
            progress += Time.deltaTime;
            if (progress >= interval && itemPool.CountActive <= maxCount)
            {
                progress -= interval;
                itemPool.Get();
            }
        }

        public void Release(Item item)
        {
            itemPool.Release(item);
        }
    }
}