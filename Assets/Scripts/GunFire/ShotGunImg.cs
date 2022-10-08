using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ShotGunImg : MonoBehaviour
{
    Image image;
    public GameObject text;
    GameObject tempDelay;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void shotGunDisable()
    {
        Color color = image.color;
        color.a = 0.5f;
        image.color = color;
        tempDelay = Instantiate(text, this.transform.position, Quaternion.identity);
        tempDelay.transform.SetParent(this.transform);
        //3�� �ڿ� ����
    }

    public void shotGunAble()
    {
        Color color = image.color;
        color.a = 0.0f;
        image.color = color;
        Destroy(tempDelay);
    }
}
