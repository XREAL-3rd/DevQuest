using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ShotGunDelay : MonoBehaviour
{
    TextMeshProUGUI delayText;
    int curTime = 3;
    float Second = 1.0f;
    float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        delayText = GetComponent<TextMeshProUGUI>();
        delayText.text = curTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer == 0.0f)
            delayText.text = (curTime--).ToString();
        timer += Time.deltaTime;
        if(timer > Second)
        {
            delayText.text = (curTime--).ToString();
            timer = 0.1f;
        }
    }
}
