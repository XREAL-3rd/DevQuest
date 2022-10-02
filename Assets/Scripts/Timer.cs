using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public float time;

    void Update()
    {
        time += Time.deltaTime;
        timeText.text = "Play Time : " + $"{time:N2}";
    }
}
