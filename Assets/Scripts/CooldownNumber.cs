using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CooldownNumber : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI text;

    private void Update()
    {
        float cooldown = GameControl.main.player.nextDashTime - Time.time;
        if (cooldown < 0)
        {
            cooldown = 0;
        }
        text.text = System.String.Format("Dash[Q] : {0:.00}s", cooldown);
    }
}
