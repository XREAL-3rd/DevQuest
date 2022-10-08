using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class BulletNum : MonoBehaviour
{
    TextMeshProUGUI bulletText;
    // Start is called before the first frame update
    void Start()
    {
        bulletText = GetComponent<TextMeshProUGUI>();
        bulletText.text = GameControl.main.player.Bullets.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void changeText()
    {
        bulletText.text = GameControl.main.player.Bullets.ToString();
    }
}
