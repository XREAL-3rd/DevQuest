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

            if (Input.GetKey(KeyCode.Q)) // Q������
            {
                anim.SetTrigger("skill_Q");
                StartCoroutine(IEInstantiatee());

            }

            else
            {
                
                fire = Instantiate(prefabFire); // �Ѿ� �����
                fire.transform.position = firePos.transform.position; // ���� ��ġ ����


            }

            anim.SetTrigger("idle");
        }
            fire.transform.Translate(dir * 0.1f); // �Ѿ� �߻�



    }

    IEnumerator IEInstantiatee()
    {
        yield return new WaitForSeconds(2.0f);
        fire = Instantiate(prefabFire_Q); // �Ѿ� �����
        fire.transform.position = firePos.transform.position; // ���� ��ġ ����



    }


}
