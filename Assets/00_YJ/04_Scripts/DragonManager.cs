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
        Shoot(); // 쏘기

    }

    void Shoot()
    {
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject()) // 좌클릭 하면
        {
            // 마우스 위치 받기 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ray로 맞으면 
            {
                dir = ray.direction; // dir에 담아주기
            }

                fire = Instantiate(prefabFire); // 총알 만들고
                fire.transform.position = firePos.transform.position; // 시작 위치 지정

        }
        
        fire.transform.Translate(dir * 0.1f); // 총알 발사

    }

}
