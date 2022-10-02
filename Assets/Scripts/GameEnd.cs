using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class GameEnd : MonoBehaviour
{
    private bool gameEnd = false;
    private float time;
    private float fin_time;
    public static float highscore;
    public static float highscore_coin;

    void Start()
    {
        highscore = PlayerPrefs.GetFloat("highscore");
        highscore_coin = PlayerPrefs.GetInt("highscore_coin");
    }

    void Update()
    {
        var targets = GameObject.FindGameObjectsWithTag("Target");
        if (targets.Length == 0)
        {
            gameEnd = true;
            EndGame();
        }
        time += Time.deltaTime;
    }

    void EndGame()
    {
        fin_time = time;
        if ((PlayerPrefs.GetFloat("highscore") == 0) | (fin_time < highscore))
        {
            PlayerPrefs.SetFloat("highscore", fin_time);
        }

        if ((PlayerPrefs.GetInt("coins") > highscore_coin))
        {
            PlayerPrefs.SetInt("highscore_coin", PlayerPrefs.GetInt("coins"));
        }
        
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene(1);
    }

    public bool IsGameEnd()
    {
        return gameEnd;
    }
}
