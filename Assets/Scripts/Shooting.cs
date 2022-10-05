using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Shooting : MonoBehaviour
{
    public Transform bow;

    public float arrow_damage = 5f;
    public float skill_damage = 20f;

    public GameObject arrow_hit_effect;
    public GameObject skill_hit_effect;

    public Animator animator;

    public bool shooting = false;

    private bool SkillEnable = true;
    public float cool_time = 10f;
    public TextMeshProUGUI cool_time_text;

    IEnumerator CoolTime()
    {
        yield return new WaitForSeconds(cool_time);
        SkillEnable = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooting = true;
            Debug.Log("Left Button Click");
            animator.SetBool("rangeAttack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
            Debug.Log("Left Button UnClick");
            RaycastHit hit_info;
            if (Physics.Raycast(bow.position, bow.forward, out hit_info))
            {
                Target target = hit_info.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.GetHit(arrow_damage);
                }
                Instantiate(arrow_hit_effect, hit_info.point, Quaternion.LookRotation(hit_info.normal));
                animator.SetBool("rangeAttack_Stop", true);
            }

        }

        if (Input.GetMouseButtonDown(1))
        {
            if (SkillEnable)
            {
                shooting = true;
                Debug.Log("Right Button Click");
                animator.SetBool("rangeAttack", true);
            }
        }
        if (Input.GetMouseButtonUp(1))
        {
            if (SkillEnable)
            {
                shooting = false;
                Debug.Log("Right Button UnClick");
                RaycastHit hit_info;
                if (Physics.Raycast(bow.position, bow.forward, out hit_info))
                {
                    Target target = hit_info.transform.GetComponent<Target>();
                    if (target != null)
                    {
                        target.GetHit(skill_damage);
                    }
                    Instantiate(skill_hit_effect, hit_info.point, Quaternion.LookRotation(new Vector3(0, 0, 1)));
                    animator.SetBool("rangeAttack_Stop", true);
                }
                SkillEnable = false;

                StartCoroutine(CoolTime());
                // cool time이 있음을 알리는 text - 10부터 아래로 세기
                // cool time이 지나면 skill을 사용할 수 있다는 text
            }
        }

        if (!SkillEnable)
        {
            cool_time_text.text = "X";
        }
        else
        {
            cool_time_text.text = null;
        }
    }
}

