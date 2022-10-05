using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStateManager : MonoBehaviour
{
    [Header ("Controls")]
    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;

    [HideInInspector] public Vector3 dir;
    float hzInput, vInput;
    CharacterController controller;

    [SerializeField] float groundYOffset;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        GetDirectionAndMove();
    }

    void GetDirectionAndMove()
    {
        hzInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        dir = transform.forward * vInput + transform.right * hzInput;

        controller.Move(dir * moveSpeed * Time.deltaTime);
    }
}
