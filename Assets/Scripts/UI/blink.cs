using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class blink : MonoBehaviour
{
    public TextMeshProUGUI msg;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(blinktext());
    }

    void Update()
	{
		if (Input.GetMouseButtonDown(0))
		{
            SceneManager.LoadScene("GameScene");

        }
	}

    IEnumerator blinktext()
    {
        Color textcolor = msg.color;
        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < 100; i++)
        {
            textcolor.a -= 0.01f;
            msg.color = textcolor;

            yield return new WaitForSeconds(0.01f);
        }
        for (int i = 0; i < 50; i++)
        {
            textcolor.a += 0.02f;
            msg.color = textcolor;

            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(blinktext());
    }
}
