using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    public PlayerControl Player => player;
    [SerializeField] private PlayerControl player;
    [SerializeField] private Image winUI;
    [SerializeField] private Image menuUI;
    private readonly HashSet<Target> targets = new HashSet<Target>();

    private bool over;

    public bool Over
    {
        get => over;
        set
        {
            //종료시 UI 보여주기
            over = value;
            winUI.gameObject.SetActive(value);
            Cursor.visible = value;
            if (value) Pause();
            else Continue();
        }
    }

    public bool UIStop { get; set; }

    Game()
    {
        //싱글톤
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }

        Instance = this;
    }

    private void Awake()
    {
        Continue();
        Cursor.visible = false;
        winUI.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (targets.Count == 0) Over = true;
    }

    private void Update()
    {
        if (UIStop) return;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (menuUI.gameObject.activeSelf)
            {
                menuUI.gameObject.SetActive(false);
                Continue();
            }
            else
            {
                menuUI.gameObject.SetActive(true);
                Pause();
            }
        }
    }

    //Target 등록
    public void AddTarget(Target target)
    {
        targets.Add(target);
    }

    //Target 등록 해제
    public void RemoveTarget(Target target)
    {
        if (targets.Remove(target) && targets.Count == 0) Over = true;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void Continue()
    {
        Time.timeScale = 1;
    }

    public void KeepPlaying()
    {
        Over = false;
    }

    public void Title()
    {
        Pause();
        SceneManager.LoadSceneAsync(0);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }
}