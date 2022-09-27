using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraControl : MonoBehaviour
{
    [Header("Settings")] public float distance = 5f;
    public float height = 2.5f;

    // public float mouseFactor = 0.2f;
    // public float xRotLock = 15f;
    public float panSpeed = 90f;

    private float panAngle;

    private Transform player;
    // private Vector3 prevMousePos;
    // private Vector3 mousePos;

    private void Start()
    {
        // Cursor.visible = false;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.forward = player.position - transform.position;
        panAngle = transform.rotation.eulerAngles.y;

        // mousePos = Input.mousePosition;
    }

    private void Update()
    {
        UpdateInput();
        // transform.position = player.transform.position - transform.rotation * Vector3.forward * distance;
        Quaternion lookdir = Quaternion.Euler(0, panAngle, 0);
        transform.position = player.transform.position - (lookdir * Vector3.forward) * distance + Vector3.up * height;

        transform.forward = player.transform.position - transform.position;
    }

    private void UpdateInput()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            panAngle -= panSpeed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            panAngle += panSpeed * Time.deltaTime;
        }
        // prevMousePos = mousePos;
        // mousePos = Input.mousePosition;
        // var pan = (mousePos - prevMousePos) * mouseFactor;
        // var euler = transform.eulerAngles;
        // euler.x -= pan.y;
        // euler.y += pan.x;
        // euler.x = euler.x > 180 ? Math.Max(euler.x, 270 + xRotLock) : Math.Min(euler.x, 90 - xRotLock);
        // transform.eulerAngles = euler;
    }
}