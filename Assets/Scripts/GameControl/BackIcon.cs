using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BackIcon : MonoBehaviour
{
    public Button btn;
    public Button quit;
    public Button undo;
    GameObject temp;

    public GameObject popUp;
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
        temp = Instantiate(popUp, this.transform.position, Quaternion.identity);
        quit = GameObject.Find("Quit").GetComponent<Button>();
        undo = GameObject.Find("Undo").GetComponent<Button>();
        quit.onClick.AddListener(Quit);
        undo.onClick.AddListener(Undo);
        temp.transform.SetParent(this.transform);
    }

    void Quit()
    {
        SceneManager.LoadScene("TitleScene");
    }

    void Undo()
    {
        Destroy(temp);
    }
}
