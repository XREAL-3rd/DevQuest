using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerAim : MonoBehaviour {
    public GameObject fireBallPrefab;
    public GameObject lightningPrefab;
    public GameObject normalHitFx;
    public GameObject criticalHitFx;

    private PlayerStatus status;
    private PlayerControl control;
    private PlayerRenderer playerRenderer;
    private Transform attackPoint;

    private const float FIREBALL_COOL = 1f;
    private const float LIGHTNING_COOL = 2f;
    private bool canFireBall = true, canLightning = true;

    private void Start() {
        status = GetComponent<PlayerStatus>();
        control = GetComponent<PlayerControl>();
        playerRenderer = transform.GetChild(0).GetComponent<PlayerRenderer>();
        attackPoint = GameObject.Find("AttackPoint").transform;
    }

    private void Update() {
        if (!control.canMove)
            return;

        if (Input.GetMouseButtonDown(0))
            HitScanAttack();
        else if (Input.GetKey(KeyCode.Q) && canFireBall)
            StartCoroutine(CastFireBall());
        else if (Input.GetKey(KeyCode.E) && canLightning)
            StartCoroutine(CastLightning());
    }

    private void HitScanAttack() {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

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

    private IEnumerator CastFireBall() {
        if (control.landed)
            playerRenderer.Cast();
        canFireBall = false;
        yield return new WaitForSeconds(0.3f);

        GameObject fireBall = Instantiate(fireBallPrefab, attackPoint.position, Quaternion.identity);
        fireBall.GetComponent<FireBall>().MagicalDamage = status.MagicalDamage;
        SkillManager.main.isFireBallCool = true;
        yield return new WaitForSeconds(FIREBALL_COOL);
        canFireBall = true;
    }

    private IEnumerator CastLightning() {
        playerRenderer.Cast();
        canLightning = false;
        yield return new WaitForSeconds(0.3f);
        
        GameObject lightning = Instantiate(lightningPrefab, attackPoint.position, Quaternion.identity);
        lightning.GetComponent<Lightning_Throw>().MagicalDamage = status.MagicalDamage;
        SkillManager.main.isLightningCool = true;
        yield return new WaitForSeconds(LIGHTNING_COOL);
        canLightning = true;
    }
}