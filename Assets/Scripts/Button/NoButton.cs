using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoButton : MonoBehaviour
{
    public GameObject HomeMenuUI;

    HomeMenu home_menu;

    void Awake()
    {
        home_menu = GameObject.Find("HomeMenu").GetComponent<HomeMenu>();
    }

    public void OnClickResume()
    {
        Resume();
        home_menu.GamePaused = false;
    }
    
    void Resume()
    {
        HomeMenuUI.SetActive(false);
        Time.timeScale = 1f; // resume the game
    }
}
