using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour {
    public GameObject fireBallPrefab;
    public GameObject normalHitFx;
    public GameObject criticalHitFx;

    private PlayerStatus status;
    private Transform attackPoint;

    private bool canFireBall = true;

    private void Start() {
        status = GetComponent<PlayerStatus>();
        attackPoint = transform.GetChild(0);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0))
            HitScanAttack();
        else if (Input.GetMouseButtonDown(1) && canFireBall)
            StartCoroutine(FireBallAttack());
    }

    private void HitScanAttack() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.CompareTag("TargetCenter")) {
                Instantiate(criticalHitFx, hit.point, Quaternion.FromToRotation(hit.point, transform.position));
                hit.transform.GetComponent<TargetHealth>().GetCriticalAttacked(status.PhysicalDamage);
            }
            else if (hit.collider.CompareTag("Target")) {
                Instantiate(normalHitFx, hit.point, Quaternion.FromToRotation(hit.point, transform.position));
                hit.transform.GetComponent<TargetHealth>().GetNormalAttacked(status.PhysicalDamage);
            }
        }
    }

    private IEnumerator FireBallAttack() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        GameObject fireBall = Instantiate(fireBallPrefab, attackPoint.position, Quaternion.identity);
        fireBall.GetComponent<FireBall>().MagicalDamage = status.MagicalDamage;
        canFireBall = false;
        yield return new WaitForSeconds(1f);
        canFireBall = true;
    }
}