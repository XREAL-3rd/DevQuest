using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pet : MonoBehaviour
{
    public Vector3 m_Movement;
    public float moveSpeed = 3f;

    public float turnSpeed = 10f;
    Rigidbody m_Rigidbody;

    void Start()
    {
      m_Rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        bool RunForward = (m_Movement != Vector3.zero);
        
        if(RunForward)
        {
            transform.rotation = Quaternion.LookRotation(m_Movement);
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        if(input != null)
        {
            m_Movement = new Vector3(input.x, 0f, input.y);  
            Debug.Log("Pet is moving!");
            PetAnimation.anim.SetTrigger("run");
        }
    }

}
