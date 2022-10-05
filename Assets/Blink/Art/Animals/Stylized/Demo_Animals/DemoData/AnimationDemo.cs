using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class AnimationDemo : MonoBehaviour
    {
        public enum AnimationType
        {
            Trigger,
            Bool
        }

        [System.Serializable]
        public class AnimationEntry
        {
            public string animationName;
            public AnimationType type;
        }
        
        public List<AnimationEntry> entries = new List<AnimationEntry>();
        public List<Animator> animators = new List<Animator>();

        public int entryIndex;

        private void Update()
        {
            if (Input.GetKey(KeyCode.Q))
            {
                NextAnimation();
            }

            if (Input.GetKey(KeyCode.E))
            {
                ReplayAnimation();
            }
        }

        public void NextAnimation()
        {
            entryIndex++;
            if (entries.Count - 1 < entryIndex) entryIndex = 0;

            PlayAnimation();
        }

        public void PreviousAnimation()
        {
            entryIndex--;
            if (entryIndex < 0) entryIndex = entries.Count - 1;
 
            PlayAnimation();
        }

        public void ReplayAnimation()
        {
            PlayAnimation();
        }

        private void ResetAllBool()
        {
            foreach (var entry in entries)
            {
                if (entry.type != AnimationType.Bool) continue;
                foreach (var animator in animators)
                {
                    animator.SetBool(entry.animationName, false);
                }
            }
        }

        private void PlayAnimation()
        {
            ResetAllBool();

            if (entries[entryIndex].type == AnimationType.Bool)
            {
                foreach (var animator in animators)
                {
                    animator.SetBool(entries[entryIndex].animationName, true);
                }
            }
            else
            {
                foreach (var animator in animators)
                {
                    animator.SetTrigger(entries[entryIndex].animationName);
                }
            }
        }
    }

