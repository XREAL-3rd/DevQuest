using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlots : MonoBehaviour
{
    [Header("Settings")] public Image skillSlot;

    private Skills skills;
    private readonly List<Image> cooldowns = new();

    private void Start()
    {
        skills = Game.Instance.Player.skills;
        foreach (var type in skills.types)
        {
            var child = Instantiate(skillSlot, transform);
            child.sprite = type.Icon;
            child.GetComponentInChildren<TextMeshProUGUI>().text = type.KeyCode.ToString();
            cooldowns.Add(child.transform.GetChild(1).GetComponent<Image>());
        }
    }

    void Update()
    {
        for (int i = 0; i < cooldowns.Count; i++) cooldowns[i].fillAmount = skills.Cooldown(i);
    }
}