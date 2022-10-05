using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    [Header("Settings")] public PlayerControl player;
    public float distance = 5f;
    public Vector3 offset;

    public float mouseFactor = 0.2f;
    public float xRotLock = 15f;

    private Vector3 prevMousePos;
    private Vector3 mousePos;

    private void Start()
    {
        transform.forward = player.transform.position - transform.position;
        mousePos = Input.mousePosition;
    }

    private void Update()
    {
        if(Game.Instance.Over) return;
        UpdateInput();
        transform.position = player.transform.position - transform.rotation * Vector3.forward * distance;
        transform.forward = player.transform.position - transform.position;
        transform.position += transform.rotation * offset;
    }

    private void UpdateInput()
    {
        prevMousePos = mousePos;
        mousePos = Input.mousePosition;
        var pan = (mousePos - prevMousePos) * mouseFactor;
        var euler = transform.eulerAngles;
        euler.x -= pan.y;
        euler.y += pan.x;
        euler.x = euler.x > 180 ? Math.Max(euler.x, 270 + xRotLock) : Math.Min(euler.x, 90 - xRotLock);
        transform.eulerAngles = euler;
    }
}