using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudLife : MonoBehaviour
{
    private int _CloudLife;
    //public GameObject cloudPrefab;
    void Start()
    {
        _CloudLife = 100;
        //newcloud = Instantiate(cloudPrefab, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Bullet(Clone)")
        {
            if (_CloudLife > 0)
            {
                _CloudLife -=10;
            }
            else
            {
                Destroy(gameObject, 3.0f);
            }
        }
       
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
