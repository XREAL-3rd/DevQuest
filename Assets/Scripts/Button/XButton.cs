using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XButton : MonoBehaviour
{
    public GameObject RuleUI;

    public void OnClickClose()
    {
        RuleUI.SetActive(false);
    }
}
