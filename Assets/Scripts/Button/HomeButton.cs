using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeButton : MonoBehaviour
{
    public GameObject HomeMenuUI;

    HomeMenu home_menu;

    void Awake()
    {
        home_menu = GameObject.Find("HomeMenu").GetComponent<HomeMenu>();
    }

    public void OnClickPopUp()
    {
        Pause();
        home_menu.GamePaused = true;
    }

    void Pause()
    {
        HomeMenuUI.SetActive(true);
        Time.timeScale = 0f; // resume the game
    }
}
