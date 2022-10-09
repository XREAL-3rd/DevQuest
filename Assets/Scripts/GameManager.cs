using System.Collections;
using System.Collections.Generic;
using UnityEngine;
<<<<<<< Updated upstream
=======
using UnityEngine.SceneManagement;
>>>>>>> Stashed changes

public class GameManager : MonoBehaviour
{
    float time; // limited time
    public List<GameObject> targetList = new List<GameObject>();
    public GameObject itemList;
<<<<<<< Updated upstream
=======
    public string SceneToLoad;
>>>>>>> Stashed changes

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
<<<<<<< Updated upstream
        if (time >= 60.0f)
        {
            IsGameOver = true;
=======
        if (time >= 60.0f || TargetControl.targetnum == 0)
        {
            IsGameOver = true;
            SceneManager.LoadScene(SceneToLoad);
            
>>>>>>> Stashed changes
        }
    }
    
}
