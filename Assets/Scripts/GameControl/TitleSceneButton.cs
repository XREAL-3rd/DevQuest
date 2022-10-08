using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSceneButton : MonoBehaviour
{
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
        btn.onClick.AddListener(btn_click);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void btn_click()
    {
        SceneManager.LoadScene("GameSceneCustom");
    }
}
