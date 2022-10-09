using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills
{
    public bool Shoot { get; private set; }
    public SkillType Current { get; private set; }

    private readonly List<SkillType> skills;
    private readonly bool[] cooldowns;

    public Skills(List<SkillType> skillTypes)
    {
        skills = skillTypes;
        cooldowns = new bool[skills.Count];
    }

    public bool TryCast(out IEnumerator coroutine)
    {
        for (int i = 0; i < skills.Count; i++)
        {
            if (Input.GetKey(skills[i].KeyCode) && !cooldowns[i])
            {
                Current = skills[i];
                cooldowns[i] = true;
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
        yield return new WaitForSeconds(skills[i].Cooldown);
        cooldowns[i] = false;
    }
}