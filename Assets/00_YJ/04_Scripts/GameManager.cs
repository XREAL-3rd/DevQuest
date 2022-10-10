using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    // �̱���
    public static GameManager instance = null;
    private void Awake()
    {
        if (instance == null) //instance�� null. ��, �ý��ۻ� �����ϰ� ���� ������
        {
            instance = this; //���ڽ��� instance�� �־�
            //DontDestroyOnLoad(gameObject); //OnLoad(���� �ε� �Ǿ�����) �ڽ��� �ı����� �ʰ� ����
        }
    }

    // �ð�
    float time;
    public List<GameObject> animalList = new List<GameObject>();

    // ������ ��ġ
    public GameObject itemList;

    // ����
    public GameObject introObject;
    public GameObject canvas_Ingame;
    public static bool startGame = false;

    // UI ����
    public Text timer;
    int limitTime=180;

    // �ߴ�
    public GameObject stopUI;

    // �����
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

        if (time >= 180.0f || animalList.Count == 0) // 3�� �����ų� ��� ���ȷΰ� �������� 
        {
            GameOver(); // ���ӿ���
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
