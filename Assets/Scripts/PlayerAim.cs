using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {
    public GameObject fireBallPrefab;
    public GameObject normalHitFx;
    public GameObject criticalHitFx;

    private Transform attackPoint;
    private RaycastHit hit;

    private void Start() {
        attackPoint = transform.GetChild(0);
        hit = new RaycastHit();
    }

    private void Update() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)) {
            if (Physics.Raycast(ray, out hit)) {
                if (hit.collider.CompareTag("TargetCenter")) {
                    Instantiate(criticalHitFx, hit.point, Quaternion.FromToRotation(hit.point, transform.position));
                    hit.transform.GetComponent<TargetHealth>().GetCriticalAttacked();
                }
                else if (hit.collider.CompareTag("Target")) {
                    Instantiate(normalHitFx, hit.point, Quaternion.FromToRotation(hit.point, transform.position));
                    hit.transform.GetComponent<TargetHealth>().GetNormalAttacked();
                }
            }
        }
        if (Input.GetMouseButtonDown(1)) {
            Instantiate(fireBallPrefab, attackPoint.position, Quaternion.FromToRotation(ray.direction, transform.position));
        }
    }
}
