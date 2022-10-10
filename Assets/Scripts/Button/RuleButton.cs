using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleButton : MonoBehaviour
{
    public GameObject RuleUI;

    void Start()
    {
        RuleUI.SetActive(false);
    }

    public void OnClickRule()
    {
        RuleUI.SetActive(true);
    }
}
