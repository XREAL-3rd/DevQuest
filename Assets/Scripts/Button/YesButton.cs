using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YesButton : MonoBehaviour
{
    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
