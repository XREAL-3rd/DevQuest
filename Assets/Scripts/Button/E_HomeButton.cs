using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class E_HomeButton : MonoBehaviour
{
    public void OnClickHome()
    {
        SceneManager.LoadScene(0);
    }
}
