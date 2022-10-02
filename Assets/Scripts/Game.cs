using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public static Game Instance { get; private set; }

    [SerializeField] private Image WinUI;
    private readonly HashSet<Target> targets = new HashSet<Target>();

    private bool over;

    public bool Over
    {
        get => over;
        set
        {
            if (!over)
            {
                //종료시 UI 보여주기
                over = value;
                WinUI.gameObject.SetActive(true);
            }
        }
    }

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
        WinUI.gameObject.SetActive(false);
    }

    private void Start()
    {
        if (targets.Count == 0) Over = true;
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
}