using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {
    [Header("Settings")]
    public float distance = 5f;
    public float height = 2.5f;
    public float panSpeed = 90f;

    private float panAngle;
    private Transform player;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        transform.forward = player.transform.position - transform.position;
        panAngle = transform.rotation.eulerAngles.y;
    }

    private void Update() {
        UpdateInput();
        Quaternion lookdir = Quaternion.Euler(0, panAngle, 0);
        transform.position = player.transform.position - (lookdir * Vector3.forward) * distance + Vector3.up * height;

        transform.forward = player.transform.position - transform.position;
    }

    private void UpdateInput() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            panAngle += panSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow)) {
            panAngle -= panSpeed * Time.deltaTime;
        }
    }
}
