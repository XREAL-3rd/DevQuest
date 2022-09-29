using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudHover : MonoBehaviour
{
    public GameObject cloud;
    private Vector3 hover_scaleChange;

    private void Awake()
    {
        hover_scaleChange = new Vector3(0.0003f, 0.0003f, 0.0003f);
    
    }
    void Start()
    {
        
    }


    private void OnMouseOver()
    {
        cloud.transform.localScale += hover_scaleChange;
        Debug.Log("Mouse Button is hovered.");
    }
    private void OnMouseExit()
    {
        
        Debug.Log("Mouse Button exit.");
    }

    private void OnMouseDown()
    {
        Vector3 mouse_position = Input.mousePosition;
        Debug.Log("Mouse Button is clicked.");
    }

    void Update()
    {
        if (cloud.transform.localScale.y < 0.3f || cloud.transform.localScale.y > 0.5f)
        {
            hover_scaleChange = -hover_scaleChange;
        }
    }


}
