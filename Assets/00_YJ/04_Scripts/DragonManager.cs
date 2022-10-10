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

    // UI �����ϱ� 
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
            Shoot(); // ���
            fire.transform.Translate(dir * 0.1f);
        }

    }

    

    void Shoot()
    {

        if (Input.GetMouseButtonDown(0) ) // ��Ŭ�� �ϰ� && UI�� �ƴϸ� 
        {

            // ���콺 ��ġ �ޱ� 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit)) // ray�� ������ 
            {
                dir = ray.direction; // dir�� ����ֱ�
                print(dir);


            }
            if (Input.GetKey(KeyCode.Q)) // Q������
            {
                // ��ų 10�� �����ٰ� ���ְ�  == �� �ٲ��ֱ�
                anim.SetTrigger("skill_Q"); // �ִϸ��̼� ������ְ� 
                skillCoolTime.color = Color.clear; // �� �ٲ��ְ� 
                StartCoroutine(IEInstantiatee());

            }

            else
            {

                fire = Instantiate(prefabFire); // �Ѿ� �����
                fire.transform.position = firePos.transform.position; // ���� ��ġ ����



            }

            //fire.transform.Translate(dir * 0.3f); // �Ѿ� �߻� > �̰� ���ڱ� �ȵż� Update�� ����� 
            anim.SetTrigger("idle");

        }

    }

    IEnumerator IEInstantiatee()
    {
        yield return new WaitForSeconds(2.0f);
        fire = Instantiate(prefabFire_Q); // �Ѿ� �����
        fire.transform.position = firePos.transform.position; // ���� ��ġ ����

        yield return new WaitForSeconds(8.0f); // 10�� �ִٰ� 
        skillCoolTime.color = Color.white; // �ٽ� �ǵ����ֱ� 



    }


}
