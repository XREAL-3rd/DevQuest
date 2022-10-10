using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager main;


    public TextMeshProUGUI bulletcount;

    public bool Rclick = true;
    public GameObject SkillOn;
    public GameObject SkillCool;
    public Image SkillFill;


    void Awake()
    {
        main = this;
    }

    public void UpdateBullet(int num)
	{
        bulletcount.text = num.ToString();
	}

    public IEnumerator CoolTime()
    {
        Rclick = false;
        SkillOn.SetActive(false);
        SkillCool.SetActive(true);

        for (int i = 0; i < 100; i++)
        {
            SkillFill.fillAmount += 0.01f;

            yield return new WaitForSeconds(0.03f);
        }

        SkillOn.SetActive(true);
        SkillCool.SetActive(false);
        SkillFill.fillAmount = 0f;
        Rclick = true;
    }

}
