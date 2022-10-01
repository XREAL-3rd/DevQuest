using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragonManager : MonoBehaviour
{
    public GameObject firePos;
    public GameObject prefabFire;
    private GameObject fire;
    public static int shootCount=2;


    public AudioSource audioPlayer;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Shoot(); // ���

    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // ��Ŭ�� �ϸ�
        {
            // ���콺 ��ġ �ޱ� 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ray�� ������ 
            {
                dir = ray.direction; // dir�� ����ֱ�
            }

                fire = Instantiate(prefabFire); // �Ѿ� �����
                fire.transform.position = firePos.transform.position; // ���� ��ġ ����

        }
        
        fire.transform.Translate(dir * 0.1f); // �Ѿ� �߻�

    }

}
