using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target;
    public Player Gun;
    public float dist = 0.5f;
    public float height = 0.2f;
    public float smoothRotate = 5.0f;
    private Transform tr;

    Ray ray;
    RaycastHit hit;
    bool aimed = false;
    int waiting = 300;
    int cur = 0;
    private Transform tempAim;
    public Transform savedAim;

    public GameObject Bullet;
    public GameObject FakeBullet;
    public Transform FirePos;

    // Start is called before the first frame update
    void Start()
    {
        tr = this.transform;
        Gun = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Follow();
        getObject();
        cur++;
    }

    public void Follow()
    {
        float currYAngle = Mathf.LerpAngle(tr.eulerAngles.y, target.eulerAngles.y + 95, smoothRotate * Time.deltaTime);

        Quaternion rot = Quaternion.Euler(0, currYAngle, 0);

        tr.position = target.position - (rot * Vector3.forward * dist) + (Vector3.up * height);

        tr.LookAt(target);
    }

    public void getObject()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // 클릭을 하면 발사
        if (Input.GetMouseButtonDown(0))
        {
            if (!GameControl.main.player.IsBullet())
            {
                Debug.Log("총알 없어!!!\n");
            }
            else if (GameControl.main.player.rebounding)
            {
                Debug.Log("반동 중 발사 불가\n");
            }
            else
            {
                if (aimed && cur < waiting)
                {
                    Debug.Log("발사\n");
                    //'Bullet'을 'FirePos.transform.position' 위치에 'FirePos.transform.rotation' 회전값으로 복제한다.         
                    GameObject tempBullet = Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
                    //3초 뒤에 삭제
                    Destroy(tempBullet, 2.0f);
                    GameControl.main.player.Decr();
                }
                else
                {
                    Debug.Log("허공발사\n");
                    //'Bullet'을 'FirePos.transform.position' 위치에 'FirePos.transform.rotation' 회전값으로 복제한다.         
                    GameObject tempBullet = Instantiate(FakeBullet, FirePos.transform.position, FirePos.transform.rotation);
                    //3초 뒤에 삭제
                    Destroy(tempBullet, 2.0f);
                    GameControl.main.player.Decr();
                }
            }
            if (savedAim)
                savedAim.gameObject.GetComponent<Aim>().changeInit();
            aimed = false;
        }
        if(cur >= waiting)
        {
            if(savedAim)
                savedAim.gameObject.GetComponent<Aim>().changeInit();
            aimed = false;
        }

        if (Physics.Raycast(ray, out hit))
        {
            // Debug.Log(hit.transform.gameObject);
            tempAim = hit.transform;
            if (tempAim.gameObject.tag == "WoodAim")
            {
                if (!aimed)
                {
                    if (savedAim)
                    {
                        savedAim.gameObject.GetComponent<Aim>().changeInit();
                    }
                    savedAim = tempAim;

                    Debug.Log("조준\n");
                    Gun.Aim(savedAim.position);
                    savedAim.gameObject.GetComponent<Aim>().changeRed();
                    aimed = true;
                    cur = 0;
                }
            }
        }
    }
}
