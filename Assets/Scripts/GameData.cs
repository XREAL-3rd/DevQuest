using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameData : Singleton<GameData>
{
    private float highscore;
    private int highscore_coin;

    public float finish_time()
    {
        highscore = PlayerPrefs.GetFloat("highscore");

        return highscore;
    }

    public int Highscore_coin()
    {
        highscore_coin = PlayerPrefs.GetInt("highscore_coin");

        return highscore_coin;
    }
}
