using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPreFab;
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 target_position = hit.point;
                Vector3 bullet_dir = target_position - transform.position;
                Quaternion bullet_rot = Quaternion.LookRotation(bullet_dir);
                Instantiate(bulletPreFab, transform.position, bullet_rot);
            }
        }
    }
}
