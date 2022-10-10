using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    public static GameControl main;

    public PlayerControl player;

    void Awake()
    {
        main = this;
        player = FindObjectOfType<PlayerControl>();
    }
}
