using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        public static Game Instance { get; private set; }

        [SerializeField] private Image WinUI;
        private readonly HashSet<Target> targets = new HashSet<Target>();

        private bool over;

        public bool Over
        {
            get => over;
            set
            {
                if (!over)
                {
                    over = value;
                    WinUI.gameObject.SetActive(true);
                }
            }
        }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }

            Instance = this;
            WinUI.gameObject.SetActive(false);
        }

        private void Start()
        {
            if (targets.Count == 0) Over = true;
        }

        public void AddTarget(Target target)
        {
            targets.Add(target);
        }

        public void RemoveTarget(Target target)
        {
            if (targets.Remove(target) && targets.Count == 0) Over = true;
        }
    }
}