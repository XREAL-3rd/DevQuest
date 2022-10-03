using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameControl : MonoBehaviour
{
    public static GameControl main;

    public NumberOfTargets targetNum;
    [HideInInspector] public Player player;

    private void Awake()
    {
        main = this;
        targetNum = GameObject.FindObjectOfType<NumberOfTargets>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        EndGame();
    }

    private void EndGame()
    {
        if (targetNum.Targets == 0)
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
