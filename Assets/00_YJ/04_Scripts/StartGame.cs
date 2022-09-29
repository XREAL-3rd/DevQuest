using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public void HideIntroUI()
    {
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }

}
