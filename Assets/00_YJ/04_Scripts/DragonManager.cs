using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragonManager : MonoBehaviour
{
    public GameObject firePos;
    public GameObject prefabFire;
    public GameObject prefabFire_Q;
    private GameObject fire;
    public static int shootCount=2;
    public Animator anim;

    // UI 연동하기 
    public Image skillCoolTime;

    Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.startGame == true)
        {
            Shoot(); // 쏘기
            fire.transform.Translate(dir * 0.1f);
        }

    }

    

    void Shoot()
    {

        if (Input.GetMouseButtonDown(0) ) // 좌클릭 하고 && UI가 아니면 
        {

            // 마우스 위치 받기 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ray로 맞으면 
            {
                dir = ray.direction; // dir에 담아주기
                print(dir);


            }
            if (Input.GetKey(KeyCode.Q)) // Q누를때
            {
                // 스킬 10초 못쓴다고 해주고  == 색 바꿔주기
                anim.SetTrigger("skill_Q"); // 애니메이션 재생해주고 
                skillCoolTime.color = Color.clear; // 색 바꿔주고 
                StartCoroutine(IEInstantiatee());

            }

            else
            {

                fire = Instantiate(prefabFire); // 총알 만들고
                fire.transform.position = firePos.transform.position; // 시작 위치 지정



            }

            //fire.transform.Translate(dir * 0.3f); // 총알 발사 > 이거 갑자기 안돼서 Update로 빼줬다 
            anim.SetTrigger("idle");

        }

    }

    IEnumerator IEInstantiatee()
    {
        yield return new WaitForSeconds(2.0f);
        fire = Instantiate(prefabFire_Q); // 총알 만들고
        fire.transform.position = firePos.transform.position; // 시작 위치 지정

        yield return new WaitForSeconds(8.0f); // 10초 있다가 
        skillCoolTime.color = Color.white; // 다시 되돌려주기 



    }


}
