using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragonManager : MonoBehaviour
{
    public GameObject firePos;
    public GameObject prefabFire;
    public GameObject prefabFire_Q;
    private GameObject fire;
    public static int shootCount=2;
    public Animator anim;

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

            if (Input.GetKey(KeyCode.Q)) // Q누를때
            {
                anim.SetTrigger("skill_Q");
                StartCoroutine(IEInstantiatee());

            }

            else
            {
                
                fire = Instantiate(prefabFire); // 총알 만들고
                fire.transform.position = firePos.transform.position; // 시작 위치 지정


            }

            anim.SetTrigger("idle");
        }
            fire.transform.Translate(dir * 0.1f); // 총알 발사



    }

    IEnumerator IEInstantiatee()
    {
        yield return new WaitForSeconds(2.0f);
        fire = Instantiate(prefabFire_Q); // 총알 만들고
        fire.transform.position = firePos.transform.position; // 시작 위치 지정



    }


}
