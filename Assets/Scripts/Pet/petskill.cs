using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//vfx in coroutine
public class petskill : MonoBehaviour
{
    public bool isDelay;
    public float delayTime = 2f;

    public GameObject skillfx;
    private Vector3 startpos;
    private Quaternion startrot;
    void Start()
    {

        startpos = this.transform.position;
        startrot = this.transform.rotation;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))//
        {
            if(!isDelay)
            {
                isDelay = true;
                Debug.Log("Special skill");
                StartCoroutine(CountSkillDelay());
                Instantiate(skillfx, startpos, startrot);
            }
            else
            {
                Debug.Log("wait..");
            }
        }
    }

    IEnumerator CountSkillDelay()
    {
        yield return new WaitForSeconds(3f);
        isDelay = false;
    }
}
