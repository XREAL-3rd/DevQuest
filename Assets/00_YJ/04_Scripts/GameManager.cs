using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // 싱글톤
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null) //instance가 null. 즉, 시스템상에 존재하고 있지 않을때
        {
            instance = this; //내자신을 instance로 넣어
            //DontDestroyOnLoad(gameObject); //OnLoad(씬이 로드 되었을때) 자신을 파괴하지 않고 유지
        }
    }

    // 시간
    float time;
    public List<GameObject> animalList = new List<GameObject>();

    // 아이템 배치
    public GameObject itemList;

    // 시작
    public GameObject introObject;
    public GameObject canvas_Ingame;
    public static bool startGame = false;

    // UI 연동
    public Text timer;
    int limitTime=180;

    // 중단
    public GameObject stopUI;

    // 재시작
    public GameObject reallyUI;

    // Start is called before the first frame update
    void Start()
    {
        itemList.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        timer.text =  (limitTime - time) + "s";

        if (time >= 180.0f || animalList.Count == 0) // 3분 지나거나 모든 버팔로가 없어지면 
        {
            GameOver(); // 게임오버
        }
    }
    public void GameStart()
    {
        introObject.SetActive(false);
        startGame = true;
        canvas_Ingame.SetActive(true);
    }

    public void ReallyRestart()
    {
        reallyUI.SetActive(true);
    }
    public void RestartYes()
    {
        SceneManager.LoadScene("HW01_YJ_StartScene");

    }

    public void GameOver()
    {
            SceneManager.LoadScene("HW01_YJ_GameOver"); 
    }


    public void StopGame()
    {
        stopUI.SetActive(true);
    }

    public void ClosePop()
    {
        stopUI.SetActive(false);
        if (reallyUI.activeSelf == true)
        {
            reallyUI.SetActive(false);
        }

    }

}
