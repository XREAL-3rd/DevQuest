using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public string moveX = "Horizontal";
    public string moveZ = "Vertical";
    public string mouseX = "Mouse X";

    // Start is called before the first frame update
        //외부에서 값 읽기만 가능
        public float move_x { get; private set; }
        public float move_z { get; private set; }
        public float mouse_x { get; private set; } //일단 남겨두자


    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxis(moveX);
        move_z = Input.GetAxis(moveZ);
        mouse_x = Input.GetAxis(mouseX);
    }
}