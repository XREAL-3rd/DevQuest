using UnityEngine;
using UnityEngine.SceneManagement;

public class GameExit : MonoBehaviour
{
    public GameObject exitPanel;

    void Start()
    {
        exitPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            exitPanel.SetActive(false);
        }
    }

    public void OnExitButtonClick()
    {
        exitPanel.SetActive(true);
    }

    public void ExitGame()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
