using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/* raycast, display crosshair*/
public class MouseTracking : MonoBehaviour
{
   
    public RectTransform transform_cursor;
    public RectTransform transform_icon;

    private void Start()
    {
        Init_Cursor();
    }
    private void Update()
    {
        Update_MousePosition();
    }

    private void Init_Cursor()
    {
        Cursor.visible = false;
        transform_cursor.pivot = Vector2.up;

        if (transform_cursor.GetComponent<Graphic>())
            transform_cursor.GetComponent<Graphic>().raycastTarget = false;
        if (transform_icon.GetComponent<Graphic>())
            transform_icon.GetComponent<Graphic>().raycastTarget = false;
    }

    private void Update_MousePosition()
    {
        Vector2 mousePos = Input.mousePosition;
        transform_cursor.position = mousePos;
        float w = transform_icon.rect.width;
        float h = transform_icon.rect.height;
        transform_icon.position = transform_cursor.position + (new Vector3(w, h) * 0.5f);
    }
}
