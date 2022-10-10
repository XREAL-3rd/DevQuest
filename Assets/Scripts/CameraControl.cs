using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour {

    public float sensitivity = 100f;

    public Transform player;
    public Transform MainCamera;
    public Transform bow;

    float rotation_x = 0f;

    public bool CursorLocked = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            
            if (CursorLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                CursorLocked = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                CursorLocked = true;
            }
        }
        // sensitivity - speed of mouse (rotation)
        // Time.deltaTime - doesn't rotate quicker if frame rate is high
        float mouse_x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouse_y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        player.Rotate(Vector3.up * mouse_x);
        bow.Rotate(Vector3.up * mouse_x);

        rotation_x -= mouse_y;
        rotation_x = Mathf.Clamp(rotation_x, -15f, 15f);
        transform.localRotation = Quaternion.Euler(rotation_x, 0f, 0f);

        bow.localRotation = Quaternion.Euler(rotation_x, 0f, 0f);
    }

    /*[Header("Settings")]
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
    }*/

}
