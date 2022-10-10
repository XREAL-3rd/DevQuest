using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeMenu : MonoBehaviour
{
    public bool GamePaused = false;

    public GameObject HomeMenuUI;

    void Start()
    {
        HomeMenuUI.SetActive(false);
    }
}
