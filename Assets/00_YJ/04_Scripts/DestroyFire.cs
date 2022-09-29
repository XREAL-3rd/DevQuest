using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFire : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject temp = collision.gameObject;

        if (temp != null)
        {
            Destroy(this.gameObject, 0.1f);

        }
    }
}
