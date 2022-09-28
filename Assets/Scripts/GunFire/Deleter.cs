using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    public GameObject aim;
    Aim saved;
    // Start is called before the first frame update
    void Start()
    {
        saved = aim.GetComponent<Aim>();
    }

    // Update is called once per frame
    void Update()
    {
        if (saved.life < 1)
        {
            Debug.Log("destroyed\n");
            Destroy(aim);
        }
    }
}
