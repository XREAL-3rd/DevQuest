using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private GameObject particle;

    private Camera mainCamera;
    private RaycastHit hit;
    
    private void Start()
    {
        mainCamera = Camera.main;
        PlayerControl.MouseClicked += OnProjectileShoot;
    }

    private void OnProjectileShoot()
    {
        var mousePosition = Input.mousePosition;
        Ray ray = mainCamera.ScreenPointToRay(mousePosition);

        Physics.Raycast(ray, out hit);

        Instantiate(particle, hit.point, Quaternion.identity);
    }
}
