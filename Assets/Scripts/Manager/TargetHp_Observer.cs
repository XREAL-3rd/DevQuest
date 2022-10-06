using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetHp_Observer : MonoBehaviour, Observer {
    public GameObject ExplosionFx;
    public GameObject hpBarPrefab;

    private GameObject hpBar;
    private Slider hpBarSlider;
    private Hp_Subject subject = null;

    public void Init(Hp_Subject subject) {
        this.subject = subject;
        hpBar = Instantiate(hpBarPrefab);
        hpBarSlider = hpBar.GetComponent<Slider>();
    }

    public void ObserverUpdate(float hp) {
        if (hp >= 0) {
            this.hpBarSlider.value = hp;
        }
        else {
            this.hpBarSlider.value = 0;
            Break();
        }
    }

    private void Break() {
        Instantiate(ExplosionFx, transform.position, Quaternion.identity);
        GameManager.TargetDestroyed(this.gameObject);
        Destroy(this.gameObject);
        hpBar.SetActive(false);
    }
}