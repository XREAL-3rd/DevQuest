using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private PlayerControl playerControl;

    void Update()
    {
        transform.position = Camera.main.WorldToScreenPoint(playerControl.Aim);
    }
}