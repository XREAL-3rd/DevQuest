using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour {
    public float mouseSensitivity = 1000f;
    private Transform playerTransform;
    private Transform attackPointTransform;

    private CinemachineVirtualCamera virtualCamera;
    private CinemachineComposer composer;
    private float mouseY = 0.6f;

    private void Start() {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        attackPointTransform = GameObject.Find("AttackPoint").transform;
        transform.forward = playerTransform.transform.position - transform.position;

        virtualCamera = GetComponent<CinemachineVirtualCamera>();
        composer = virtualCamera.GetCinemachineComponent<CinemachineComposer>();
    }

    private void Update() {
        SetCameraRotation();
        SetCameraPosition();
        SetAttackPointPosition();
    }

    private void SetCameraRotation() {
        SetCameraRotationX();
        SetCameraRotationY();
    }

    private void SetCameraRotationX() {
        float h = Input.GetAxis("Mouse X");
        transform.RotateAround(playerTransform.transform.position, Vector3.up, h * mouseSensitivity * Time.deltaTime);
    }

    private void SetCameraRotationY() {
        float v = Input.GetAxis("Mouse Y");
        mouseY += v * mouseSensitivity / 100f * Time.deltaTime;
        mouseY = Mathf.Clamp(mouseY, -0.5f, 1.5f);

        composer.m_ScreenY = mouseY;
    }

    private void SetCameraPosition() {
        Vector2 playerPos = new Vector2(playerTransform.transform.position.x, playerTransform.transform.position.z);
        Vector3 camPos = new Vector2(transform.position.x, transform.position.z);
        float distance = Vector2.Distance(playerPos, camPos);

        Vector3 deltaPosition = (playerTransform.transform.position - transform.position).normalized * (distance - 4f);
        deltaPosition.y = 0;
        transform.position += deltaPosition;
    }

    private void SetAttackPointPosition() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 position = ray.origin + ray.direction * 6f;
        position.y = playerTransform.position.y;
        attackPointTransform.position = position;
    }
}
