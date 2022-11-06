using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootArrow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public GameObject arrow;
    public Vector3 arrowPos;
    private Camera cam;
    private Vector3 objPosition = new Vector3(0, 0, 0);

    public void Start()
    {
        arrowPos = new Vector3(-0.2f, 0.78f, 0.56f);
        cam = Camera.main;
    }

    public void Update()
    {
        arrowPos = transform.Find("ArrowPos").gameObject.transform.position;
    }

    public void Arrow()
    {
        arrow = Instantiate(arrowPrefab, arrowPos, Quaternion.identity);
        MousePos();
        Arrow arrowscript = arrow.GetComponent<Arrow>();
        arrowscript.setDir(objPosition);
    }
    
    public void MousePos()
    {
        Vector2 screenPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        var ray = Camera.main.ScreenPointToRay(screenPos);
        if(Physics.Raycast(ray, out RaycastHit hit, 500.0f, LayerMask.GetMask("Ground")))
        {
            objPosition = hit.point;
        }
    }
}
