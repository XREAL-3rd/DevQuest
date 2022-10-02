using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    private float highscore_time;
    private int highscore_coin;

    public TextMeshProUGUI highscore_text;
    public TextMeshProUGUI highscore_coin_text;

    void GetGameData()
    {
        highscore_time = GameData.Instance.finish_time();
        highscore_coin = GameData.Instance.Highscore_coin();
        ShowGameData();
    }

    void ShowGameData()
    {
        highscore_text.text = "Highscore time : " + $"{highscore_time:N2}";
        highscore_coin_text.text = "Highscore Coin : " + highscore_coin;
    }

    void Update()
    {
        GetGameData();
    }
}
