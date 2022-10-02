using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shooting : MonoBehaviour
{
    public Transform bow;

    public float arrow_damage = 5f;

    public GameObject arrow_hit_effect;

    public Animator animator;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            shooting = true;
            Debug.Log("Left Button Click");
            animator.SetBool("rangeAttack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            shooting = false;
            Debug.Log("Left Button UnClick");
            RaycastHit hit_info;
            if (Physics.Raycast(bow.position, bow.forward, out hit_info))
            {
                Target target = hit_info.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.GetHit(arrow_damage);
                }
                Instantiate(arrow_hit_effect, hit_info.point, Quaternion.LookRotation(hit_info.normal));
                animator.SetBool("rangeAttack_Stop", true);
                // I couldn't make attacking animation smoothly, 
                // so I added another boolean trigger called 'rangeAttack_Stop'.
                // I want to know how I should have done.
            }
            
        }
    }
}
