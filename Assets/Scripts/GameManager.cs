using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    float time; // limited time
    public List<GameObject> targetList = new List<GameObject>();
    public GameObject itemList;

    //Game over state
    private bool isGameOver;    
    public bool IsGameOver
    {
        get{return isGameOver;}
        set{
            isGameOver = value;
            if(isGameOver)
            {
                Debug.Log("GAME OVER");//game ending scene만들어서 바꾸기

                itemList.SetActive(false); //item 비활성화
            }
        }
    }
    //Singleton
    private static GameManager instance = null;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;   
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
            DontDestroyOnLoad(this.gameObject);
    }

    public void Start()
    {
        IsGameOver = false; //초기값설정
        itemList.SetActive(true); //item 활성화
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time >= 60.0f || targetList.Count == 0)//60초 후 종료, targetlist 개수가 안줄음...........
        {
            IsGameOver = true;
        }
    }
    
}
