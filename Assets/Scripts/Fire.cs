using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bulletPreFab;

    public PlayerRenderer playerRenderer;

    public Camera cam;

    private float lastRangeAttack = -100.0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time > lastRangeAttack + 1.0f)
        {
            lastRangeAttack = Time.time;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Vector3 target_position = hit.point;
                Vector3 bullet_dir =
                    (target_position - transform.position).normalized;
                Quaternion bullet_rot = Quaternion.LookRotation(bullet_dir);
                playerRenderer
                    .RangeAttack(new Vector3(bullet_dir.x, 0, bullet_dir.z));
                StartCoroutine(SpawnBulletLater(transform.position + bullet_dir,
                bullet_rot));
            }
        }
    }

    IEnumerator SpawnBulletLater(Vector3 position, Quaternion rotation)
    {
        yield return new WaitForSeconds(1.0f);
        Instantiate (bulletPreFab, position, rotation);
    }
}
