using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillManager : MonoBehaviour {
    public static SkillManager main;

    public bool isFireBallCool, isLightningCool;
    public float fireBallCoolTime = 0;
    public float lightningCoolTime = 0;

    public TextMeshProUGUI fireballTMP, lightningTMP;
    public Image fireballImage, lightningImage;
    private Coroutine fireball, lightning;

    private void Awake() {
        if (main != null && main != this)
            Destroy(gameObject);
        else
            main = this;
    }

    private void Update() {
        if (isFireBallCool && fireball == null)
            fireball = StartCoroutine(CheckFireBallCool());

        if (isLightningCool && lightning == null)
            lightning = StartCoroutine(CheckLightningCool());
    }

    private IEnumerator CheckFireBallCool() {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.01f);
        fireBallCoolTime = 1f;
        Color color = fireballImage.color;
        color.a = 1f;
        fireballImage.color = color;

        for (int i = 0; i < 100; i++) {
            fireBallCoolTime -= 0.01f;
            fireballTMP.text = string.Format("{0:0.0}", fireBallCoolTime);
            color.a -= 200f / 255f / 100f;
            fireballImage.color = color;
            yield return waitForSeconds;
        }

        fireBallCoolTime = 0;
        fireballTMP.text = "";
        isFireBallCool = false;
        fireball = null;
    }

    private IEnumerator CheckLightningCool() {
        WaitForSeconds waitForSeconds = new WaitForSeconds(0.01f);
        lightningCoolTime = 2f;
        Color color = lightningImage.color;
        color.a = 1f;
        lightningImage.color = color;

        for (int i = 0; i < 200; i++) {
            lightningCoolTime -= 0.01f;
            lightningTMP.text = string.Format("{0:0.0}", lightningCoolTime);
            color.a -= 200f / 255f / 200f;
            lightningImage.color = color;
            yield return waitForSeconds;
        }

        lightningCoolTime = 0;
        lightningTMP.text = "";
        isLightningCool = false;
        color.a = 0f;
        lightningImage.color = color;

        lightning = null;
    }
}
