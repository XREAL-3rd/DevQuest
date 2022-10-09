using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{
    public bool Shoot { get; private set; }
    public SkillType Current { get; private set; }
    public readonly List<SkillType> types;

    private readonly float[] cooldowns;

    public Skills(List<SkillType> types)
    {
        this.types = types;
        cooldowns = new float[types.Count];
    }

    public bool TryCast(out IEnumerator coroutine)
    {
        for (int i = 0; i < types.Count; i++)
        {
            if (Input.GetKey(types[i].KeyCode) && cooldowns[i] <= 0)
            {
                Current = types[i];
                cooldowns[i] = 1;
                coroutine = CooldownCoroutine(i);
                return true;
            }
        }

        coroutine = null;
        return false;
    }

    public void OnCast()
    {
        Shoot = true;
    }

    public void OnCastEnded()
    {
        Shoot = false;
    }

    public IEnumerator CooldownCoroutine(int i)
    {
        cooldowns[i] -= Time.deltaTime;
        while (cooldowns[i] > 0)
        {
            yield return new WaitForEndOfFrame();
            cooldowns[i] -= Time.deltaTime / types[i].Cooldown;
        }
    }

    public float Cooldown(int i) => cooldowns[i];
}