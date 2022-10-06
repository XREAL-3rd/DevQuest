using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetAnimation : MonoBehaviour
{
    public static Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetTrigger("eat");
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            anim.SetTrigger("buff");
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            anim.SetTrigger("sit");
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            anim.SetTrigger("sleep");
        }

    }
}
